

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
  public class tblCustomersTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblCustomersTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblCustomers",
        ColumnMappings = {
          {
            "ID",
            "ID"
          },
          {
            "CID",
            "CID"
          },
          {
            "CName",
            "CName"
          },
          {
            "CPhone",
            "CPhone"
          },
          {
            "CCell",
            "CCell"
          },
          {
            "CNo",
            "CNo"
          },
          {
            "CAddr1",
            "CAddr1"
          },
          {
            "CAddr2",
            "CAddr2"
          },
          {
            "CAddr3",
            "CAddr3"
          },
          {
            "CCity",
            "CCity"
          },
          {
            "CPincode",
            "CPincode"
          },
          {
            "CIntroducer",
            "CIntroducer"
          },
          {
            "CAadharNumber",
            "CAadharNumber"
          },
          {
            "COtherProof",
            "COtherProof"
          },
          {
            "CRationCard",
            "CRationCard"
          },
          {
            "CInterestRate",
            "CInterestRate"
          },
          {
            "CEmail",
            "CEmail"
          },
          {
            "CImagePath",
            "CImagePath"
          },
          {
            "CNotes",
            "CNotes"
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
            "FatherName",
            "FatherName"
          },
          {
            "MotherName",
            "MotherName"
          },
          {
            "SpouseName",
            "SpouseName"
          },
          {
            "Sex",
            "Sex"
          },
          {
            "FingerPrint",
            "FingerPrint"
          },
          {
            "SampleNumber",
            "SampleNumber"
          },
          {
            "ImageFile",
            "ImageFile"
          },
          {
            "FingerNumber",
            "FingerNumber"
          },
          {
            "IdCardIssued",
            "IdCardIssued"
          },
          {
            "Dob",
            "Dob"
          },
          {
            "Occupation",
            "Occupation"
          },
          {
            "Education",
            "Education"
          },
          {
            "MaritalStatus",
            "MaritalStatus"
          },
          {
            "Religion",
            "Religion"
          },
          {
            "State",
            "State"
          },
          {
            "Landmark",
            "Landmark"
          },
          {
            "HouseType",
            "HouseType"
          },
          {
            "OwnerShip",
            "OwnerShip"
          },
          {
            "PNo",
            "PNo"
          },
          {
            "PAddr1",
            "PAddr1"
          },
          {
            "PAddr2",
            "PAddr2"
          },
          {
            "PAddr3",
            "PAddr3"
          },
          {
            "PCity",
            "PCity"
          },
          {
            "PPincode",
            "PPincode"
          },
          {
            "PState",
            "PState"
          },
          {
            "PLandMark",
            "PLandMark"
          },
          {
            "PHouseType",
            "PHouseType"
          },
          {
            "POwnership",
            "POwnership"
          },
          {
            "VoterId",
            "VoterId"
          },
          {
            "Passport",
            "Passport"
          },
          {
            "DrivingLicense",
            "DrivingLicense"
          },
          {
            "PanCard",
            "PanCard"
          },
          {
            "BankCode",
            "BankCode"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblCustomers` WHERE (((? = 1 AND `ID` IS NULL) OR (`ID` = ?)) AND (`CID` = ?) AND ((? = 1 AND `CName` IS NULL) OR (`CName` = ?)) AND ((? = 1 AND `CPhone` IS NULL) OR (`CPhone` = ?)) AND ((? = 1 AND `CCell` IS NULL) OR (`CCell` = ?)) AND ((? = 1 AND `CNo` IS NULL) OR (`CNo` = ?)) AND ((? = 1 AND `CAddr1` IS NULL) OR (`CAddr1` = ?)) AND ((? = 1 AND `CAddr2` IS NULL) OR (`CAddr2` = ?)) AND ((? = 1 AND `CAddr3` IS NULL) OR (`CAddr3` = ?)) AND ((? = 1 AND `CCity` IS NULL) OR (`CCity` = ?)) AND ((? = 1 AND `CPincode` IS NULL) OR (`CPincode` = ?)) AND ((? = 1 AND `CIntroducer` IS NULL) OR (`CIntroducer` = ?)) AND ((? = 1 AND `CAadharNumber` IS NULL) OR (`CAadharNumber` = ?)) AND ((? = 1 AND `COtherProof` IS NULL) OR (`COtherProof` = ?)) AND ((? = 1 AND `CRationCard` IS NULL) OR (`CRationCard` = ?)) AND ((? = 1 AND `CInterestRate` IS NULL) OR (`CInterestRate` = ?)) AND ((? = 1 AND `CEmail` IS NULL) OR (`CEmail` = ?)) AND ((? = 1 AND `CImagePath` IS NULL) OR (`CImagePath` = ?)) AND ((? = 1 AND `CNotes` IS NULL) OR (`CNotes` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `FatherName` IS NULL) OR (`FatherName` = ?)) AND ((? = 1 AND `MotherName` IS NULL) OR (`MotherName` = ?)) AND ((? = 1 AND `SpouseName` IS NULL) OR (`SpouseName` = ?)) AND ((? = 1 AND `Sex` IS NULL) OR (`Sex` = ?)) AND ((? = 1 AND `SampleNumber` IS NULL) OR (`SampleNumber` = ?)) AND ((? = 1 AND `ImageFile` IS NULL) OR (`ImageFile` = ?)) AND ((? = 1 AND `FingerNumber` IS NULL) OR (`FingerNumber` = ?)) AND ((? = 1 AND `IdCardIssued` IS NULL) OR (`IdCardIssued` = ?)) AND ((? = 1 AND `BankCode` IS NULL) OR (`BankCode` = ?)) AND ((? = 1 AND `Dob` IS NULL) OR (`Dob` = ?)) AND ((? = 1 AND `DrivingLicense` IS NULL) OR (`DrivingLicense` = ?)) AND ((? = 1 AND `Education` IS NULL) OR (`Education` = ?)) AND ((? = 1 AND `HouseType` IS NULL) OR (`HouseType` = ?)) AND ((? = 1 AND `Landmark` IS NULL) OR (`Landmark` = ?)) AND ((? = 1 AND `MaritalStatus` IS NULL) OR (`MaritalStatus` = ?)) AND ((? = 1 AND `Occupation` IS NULL) OR (`Occupation` = ?)) AND ((? = 1 AND `OwnerShip` IS NULL) OR (`OwnerShip` = ?)) AND ((? = 1 AND `PAddr1` IS NULL) OR (`PAddr1` = ?)) AND ((? = 1 AND `PAddr2` IS NULL) OR (`PAddr2` = ?)) AND ((? = 1 AND `PAddr3` IS NULL) OR (`PAddr3` = ?)) AND ((? = 1 AND `PCity` IS NULL) OR (`PCity` = ?)) AND ((? = 1 AND `PHouseType` IS NULL) OR (`PHouseType` = ?)) AND ((? = 1 AND `PLandMark` IS NULL) OR (`PLandMark` = ?)) AND ((? = 1 AND `PNo` IS NULL) OR (`PNo` = ?)) AND ((? = 1 AND `POwnership` IS NULL) OR (`POwnership` = ?)) AND ((? = 1 AND `PPincode` IS NULL) OR (`PPincode` = ?)) AND ((? = 1 AND `PState` IS NULL) OR (`PState` = ?)) AND ((? = 1 AND `PanCard` IS NULL) OR (`PanCard` = ?)) AND ((? = 1 AND `Passport` IS NULL) OR (`Passport` = ?)) AND ((? = 1 AND `Religion` IS NULL) OR (`Religion` = ?)) AND ((? = 1 AND `State` IS NULL) OR (`State` = ?)) AND ((? = 1 AND `VoterId` IS NULL) OR (`VoterId` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CID", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CPhone", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CPhone", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CPhone", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CPhone", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CCell", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CCell", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CCell", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CCell", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CNo", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CNo", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CNo", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CNo", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CAddr1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr1", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CAddr1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr1", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CAddr2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr2", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CAddr2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr2", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CAddr3", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr3", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CAddr3", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr3", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CCity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CCity", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CCity", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CCity", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CPincode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CPincode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CPincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CPincode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CIntroducer", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CIntroducer", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CIntroducer", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CIntroducer", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CAadharNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAadharNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CAadharNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAadharNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_COtherProof", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "COtherProof", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_COtherProof", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "COtherProof", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CRationCard", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CRationCard", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CRationCard", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CRationCard", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CInterestRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CInterestRate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CInterestRate", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CInterestRate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CEmail", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CEmail", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CEmail", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CEmail", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CImagePath", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CImagePath", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CImagePath", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CNotes", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CNotes", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CNotes", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CNotes", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_FatherName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FatherName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_FatherName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FatherName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_MotherName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MotherName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_MotherName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MotherName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_SpouseName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SpouseName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_SpouseName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SpouseName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Sex", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Sex", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Sex", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Sex", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_SampleNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SampleNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_SampleNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SampleNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ImageFile", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ImageFile", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ImageFile", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ImageFile", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_FingerNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FingerNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_FingerNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FingerNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_IdCardIssued", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCardIssued", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_IdCardIssued", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCardIssued", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BankCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Dob", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Dob", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Dob", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Dob", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_DrivingLicense", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DrivingLicense", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_DrivingLicense", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DrivingLicense", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Education", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Education", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Education", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Education", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_HouseType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HouseType", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_HouseType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HouseType", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Landmark", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Landmark", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Landmark", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Landmark", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_MaritalStatus", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaritalStatus", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_MaritalStatus", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaritalStatus", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Occupation", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Occupation", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Occupation", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Occupation", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_OwnerShip", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OwnerShip", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_OwnerShip", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OwnerShip", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PAddr1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr1", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PAddr1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr1", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PAddr2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr2", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PAddr2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr2", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PAddr3", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr3", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PAddr3", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr3", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PCity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PCity", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PCity", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PCity", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PHouseType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PHouseType", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PHouseType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PHouseType", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PLandMark", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PLandMark", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PLandMark", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PLandMark", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PNo", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PNo", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PNo", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PNo", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_POwnership", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "POwnership", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_POwnership", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "POwnership", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PPincode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PPincode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PPincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PPincode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PState", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PState", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PState", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PState", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PanCard", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PanCard", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PanCard", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PanCard", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Passport", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Passport", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Passport", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Passport", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Religion", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Religion", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Religion", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Religion", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_State", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "State", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_State", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "State", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_VoterId", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoterId", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_VoterId", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoterId", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblCustomers` (`CID`, `CName`, `CPhone`, `CCell`, `CNo`, `CAddr1`, `CAddr2`, `CAddr3`, `CCity`, `CPincode`, `CIntroducer`, `CAadharNumber`, `COtherProof`, `CRationCard`, `CInterestRate`, `CEmail`, `CImagePath`, `CNotes`, `CreatedBy`, `CreatedOn`, `FatherName`, `MotherName`, `SpouseName`, `Sex`, `FingerPrint`, `SampleNumber`, `ImageFile`, `FingerNumber`, `IdCardIssued`, `BankCode`, `Dob`, `DrivingLicense`, `Education`, `HouseType`, `Landmark`, `MaritalStatus`, `Occupation`, `OwnerShip`, `PAddr1`, `PAddr2`, `PAddr3`, `PCity`, `PHouseType`, `PLandMark`, `PNo`, `POwnership`, `PPincode`, `PState`, `PanCard`, `Passport`, `Religion`, `State`, `VoterId`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CID", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CID", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CPhone", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CPhone", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CCell", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CCell", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CNo", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CNo", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CAddr1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr1", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CAddr2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr2", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CAddr3", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr3", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CCity", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CCity", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CPincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CPincode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CIntroducer", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CIntroducer", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CAadharNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAadharNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("COtherProof", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "COtherProof", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CRationCard", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CRationCard", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CInterestRate", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CInterestRate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CEmail", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CEmail", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CImagePath", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CNotes", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CNotes", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("FatherName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FatherName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("MotherName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MotherName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SpouseName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SpouseName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Sex", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Sex", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("FingerPrint", OleDbType.LongVarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FingerPrint", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SampleNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SampleNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ImageFile", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ImageFile", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("FingerNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FingerNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("IdCardIssued", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCardIssued", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Dob", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Dob", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("DrivingLicense", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DrivingLicense", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Education", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Education", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("HouseType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HouseType", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Landmark", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Landmark", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("MaritalStatus", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaritalStatus", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Occupation", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Occupation", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("OwnerShip", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OwnerShip", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PAddr1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr1", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PAddr2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr2", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PAddr3", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr3", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PCity", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PCity", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PHouseType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PHouseType", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PLandMark", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PLandMark", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PNo", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PNo", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("POwnership", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "POwnership", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PPincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PPincode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PState", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PState", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PanCard", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PanCard", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Passport", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Passport", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Religion", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Religion", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("State", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "State", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("VoterId", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoterId", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblCustomers` SET `CID` = ?, `CName` = ?, `CPhone` = ?, `CCell` = ?, `CNo` = ?, `CAddr1` = ?, `CAddr2` = ?, `CAddr3` = ?, `CCity` = ?, `CPincode` = ?, `CIntroducer` = ?, `CAadharNumber` = ?, `COtherProof` = ?, `CRationCard` = ?, `CInterestRate` = ?, `CEmail` = ?, `CImagePath` = ?, `CNotes` = ?, `CreatedBy` = ?, `CreatedOn` = ?, `FatherName` = ?, `MotherName` = ?, `SpouseName` = ?, `Sex` = ?, `FingerPrint` = ?, `SampleNumber` = ?, `ImageFile` = ?, `FingerNumber` = ?, `IdCardIssued` = ?, `BankCode` = ?, `Dob` = ?, `DrivingLicense` = ?, `Education` = ?, `HouseType` = ?, `Landmark` = ?, `MaritalStatus` = ?, `Occupation` = ?, `OwnerShip` = ?, `PAddr1` = ?, `PAddr2` = ?, `PAddr3` = ?, `PCity` = ?, `PHouseType` = ?, `PLandMark` = ?, `PNo` = ?, `POwnership` = ?, `PPincode` = ?, `PState` = ?, `PanCard` = ?, `Passport` = ?, `Religion` = ?, `State` = ?, `VoterId` = ? WHERE (((? = 1 AND `ID` IS NULL) OR (`ID` = ?)) AND (`CID` = ?) AND ((? = 1 AND `CName` IS NULL) OR (`CName` = ?)) AND ((? = 1 AND `CPhone` IS NULL) OR (`CPhone` = ?)) AND ((? = 1 AND `CCell` IS NULL) OR (`CCell` = ?)) AND ((? = 1 AND `CNo` IS NULL) OR (`CNo` = ?)) AND ((? = 1 AND `CAddr1` IS NULL) OR (`CAddr1` = ?)) AND ((? = 1 AND `CAddr2` IS NULL) OR (`CAddr2` = ?)) AND ((? = 1 AND `CAddr3` IS NULL) OR (`CAddr3` = ?)) AND ((? = 1 AND `CCity` IS NULL) OR (`CCity` = ?)) AND ((? = 1 AND `CPincode` IS NULL) OR (`CPincode` = ?)) AND ((? = 1 AND `CIntroducer` IS NULL) OR (`CIntroducer` = ?)) AND ((? = 1 AND `CAadharNumber` IS NULL) OR (`CAadharNumber` = ?)) AND ((? = 1 AND `COtherProof` IS NULL) OR (`COtherProof` = ?)) AND ((? = 1 AND `CRationCard` IS NULL) OR (`CRationCard` = ?)) AND ((? = 1 AND `CInterestRate` IS NULL) OR (`CInterestRate` = ?)) AND ((? = 1 AND `CEmail` IS NULL) OR (`CEmail` = ?)) AND ((? = 1 AND `CImagePath` IS NULL) OR (`CImagePath` = ?)) AND ((? = 1 AND `CNotes` IS NULL) OR (`CNotes` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `FatherName` IS NULL) OR (`FatherName` = ?)) AND ((? = 1 AND `MotherName` IS NULL) OR (`MotherName` = ?)) AND ((? = 1 AND `SpouseName` IS NULL) OR (`SpouseName` = ?)) AND ((? = 1 AND `Sex` IS NULL) OR (`Sex` = ?)) AND ((? = 1 AND `SampleNumber` IS NULL) OR (`SampleNumber` = ?)) AND ((? = 1 AND `ImageFile` IS NULL) OR (`ImageFile` = ?)) AND ((? = 1 AND `FingerNumber` IS NULL) OR (`FingerNumber` = ?)) AND ((? = 1 AND `IdCardIssued` IS NULL) OR (`IdCardIssued` = ?)) AND ((? = 1 AND `BankCode` IS NULL) OR (`BankCode` = ?)) AND ((? = 1 AND `Dob` IS NULL) OR (`Dob` = ?)) AND ((? = 1 AND `DrivingLicense` IS NULL) OR (`DrivingLicense` = ?)) AND ((? = 1 AND `Education` IS NULL) OR (`Education` = ?)) AND ((? = 1 AND `HouseType` IS NULL) OR (`HouseType` = ?)) AND ((? = 1 AND `Landmark` IS NULL) OR (`Landmark` = ?)) AND ((? = 1 AND `MaritalStatus` IS NULL) OR (`MaritalStatus` = ?)) AND ((? = 1 AND `Occupation` IS NULL) OR (`Occupation` = ?)) AND ((? = 1 AND `OwnerShip` IS NULL) OR (`OwnerShip` = ?)) AND ((? = 1 AND `PAddr1` IS NULL) OR (`PAddr1` = ?)) AND ((? = 1 AND `PAddr2` IS NULL) OR (`PAddr2` = ?)) AND ((? = 1 AND `PAddr3` IS NULL) OR (`PAddr3` = ?)) AND ((? = 1 AND `PCity` IS NULL) OR (`PCity` = ?)) AND ((? = 1 AND `PHouseType` IS NULL) OR (`PHouseType` = ?)) AND ((? = 1 AND `PLandMark` IS NULL) OR (`PLandMark` = ?)) AND ((? = 1 AND `PNo` IS NULL) OR (`PNo` = ?)) AND ((? = 1 AND `POwnership` IS NULL) OR (`POwnership` = ?)) AND ((? = 1 AND `PPincode` IS NULL) OR (`PPincode` = ?)) AND ((? = 1 AND `PState` IS NULL) OR (`PState` = ?)) AND ((? = 1 AND `PanCard` IS NULL) OR (`PanCard` = ?)) AND ((? = 1 AND `Passport` IS NULL) OR (`Passport` = ?)) AND ((? = 1 AND `Religion` IS NULL) OR (`Religion` = ?)) AND ((? = 1 AND `State` IS NULL) OR (`State` = ?)) AND ((? = 1 AND `VoterId` IS NULL) OR (`VoterId` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CID", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CID", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CPhone", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CPhone", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CCell", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CCell", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CNo", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CNo", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CAddr1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr1", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CAddr2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr2", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CAddr3", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr3", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CCity", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CCity", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CPincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CPincode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CIntroducer", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CIntroducer", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CAadharNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAadharNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("COtherProof", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "COtherProof", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CRationCard", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CRationCard", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CInterestRate", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CInterestRate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CEmail", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CEmail", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CImagePath", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CNotes", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CNotes", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("FatherName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FatherName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("MotherName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MotherName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("SpouseName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SpouseName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Sex", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Sex", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("FingerPrint", OleDbType.LongVarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FingerPrint", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("SampleNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SampleNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ImageFile", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ImageFile", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("FingerNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FingerNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IdCardIssued", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCardIssued", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Dob", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Dob", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("DrivingLicense", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DrivingLicense", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Education", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Education", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("HouseType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HouseType", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Landmark", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Landmark", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("MaritalStatus", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaritalStatus", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Occupation", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Occupation", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("OwnerShip", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OwnerShip", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PAddr1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr1", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PAddr2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr2", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PAddr3", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr3", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PCity", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PCity", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PHouseType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PHouseType", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PLandMark", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PLandMark", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PNo", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PNo", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("POwnership", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "POwnership", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PPincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PPincode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PState", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PState", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PanCard", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PanCard", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Passport", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Passport", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Religion", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Religion", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("State", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "State", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("VoterId", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoterId", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CID", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CPhone", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CPhone", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CPhone", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CPhone", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CCell", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CCell", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CCell", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CCell", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CNo", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CNo", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CNo", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CNo", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CAddr1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr1", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CAddr1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr1", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CAddr2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr2", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CAddr2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr2", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CAddr3", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr3", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CAddr3", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAddr3", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CCity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CCity", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CCity", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CCity", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CPincode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CPincode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CPincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CPincode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CIntroducer", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CIntroducer", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CIntroducer", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CIntroducer", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CAadharNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAadharNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CAadharNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CAadharNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_COtherProof", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "COtherProof", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_COtherProof", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "COtherProof", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CRationCard", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CRationCard", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CRationCard", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CRationCard", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CInterestRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CInterestRate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CInterestRate", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CInterestRate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CEmail", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CEmail", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CEmail", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CEmail", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CImagePath", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CImagePath", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CImagePath", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CNotes", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CNotes", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CNotes", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CNotes", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_FatherName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FatherName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_FatherName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FatherName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_MotherName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MotherName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_MotherName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MotherName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_SpouseName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SpouseName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_SpouseName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SpouseName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Sex", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Sex", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Sex", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Sex", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_SampleNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SampleNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_SampleNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SampleNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ImageFile", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ImageFile", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ImageFile", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ImageFile", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_FingerNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FingerNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_FingerNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FingerNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_IdCardIssued", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCardIssued", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_IdCardIssued", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCardIssued", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BankCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Dob", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Dob", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Dob", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Dob", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_DrivingLicense", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DrivingLicense", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_DrivingLicense", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DrivingLicense", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Education", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Education", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Education", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Education", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_HouseType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HouseType", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_HouseType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HouseType", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Landmark", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Landmark", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Landmark", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Landmark", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_MaritalStatus", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaritalStatus", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_MaritalStatus", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaritalStatus", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Occupation", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Occupation", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Occupation", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Occupation", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_OwnerShip", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OwnerShip", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_OwnerShip", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OwnerShip", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PAddr1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr1", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PAddr1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr1", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PAddr2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr2", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PAddr2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr2", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PAddr3", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr3", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PAddr3", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PAddr3", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PCity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PCity", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PCity", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PCity", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PHouseType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PHouseType", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PHouseType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PHouseType", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PLandMark", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PLandMark", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PLandMark", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PLandMark", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PNo", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PNo", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PNo", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PNo", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_POwnership", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "POwnership", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_POwnership", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "POwnership", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PPincode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PPincode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PPincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PPincode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PState", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PState", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PState", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PState", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PanCard", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PanCard", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PanCard", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PanCard", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Passport", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Passport", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Passport", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Passport", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Religion", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Religion", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Religion", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Religion", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_State", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "State", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_State", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "State", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_VoterId", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoterId", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_VoterId", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoterId", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, CID, CName, CPhone, CCell, CNo, CAddr1, CAddr2, CAddr3, CCity, CPincode, CIntroducer, CAadharNumber, COtherProof, CRationCard, CInterestRate, CEmail, CImagePath, CNotes, CreatedBy, CreatedOn, FatherName, MotherName, SpouseName, Sex, FingerPrint, SampleNumber, ImageFile, FingerNumber, IdCardIssued, BankCode, Dob, DrivingLicense, Education, HouseType, Landmark, MaritalStatus, Occupation, OwnerShip, PAddr1, PAddr2, PAddr3, PCity, PHouseType, PLandMark, PNo, POwnership, PPincode, PState, PanCard, Passport, Religion, State, VoterId FROM tblCustomers";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblCustomersDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblCustomersDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblCustomersDataTable data = new pawnmanagementDataSet1.tblCustomersDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblCustomersDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblCustomers");

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
      string Original_CID,
      string Original_CName,
      string Original_CPhone,
      string Original_CCell,
      string Original_CNo,
      string Original_CAddr1,
      string Original_CAddr2,
      string Original_CAddr3,
      string Original_CCity,
      string Original_CPincode,
      string Original_CIntroducer,
      string Original_CAadharNumber,
      string Original_COtherProof,
      string Original_CRationCard,
      string Original_CInterestRate,
      string Original_CEmail,
      string Original_CImagePath,
      string Original_CNotes,
      string Original_CreatedBy,
      DateTime? Original_CreatedOn,
      string Original_FatherName,
      string Original_MotherName,
      string Original_SpouseName,
      string Original_Sex,
      string Original_SampleNumber,
      string Original_ImageFile,
      int? Original_FingerNumber,
      string Original_IdCardIssued,
      string Original_BankCode,
      DateTime? Original_Dob,
      string Original_DrivingLicense,
      string Original_Education,
      string Original_HouseType,
      string Original_Landmark,
      string Original_MaritalStatus,
      string Original_Occupation,
      string Original_OwnerShip,
      string Original_PAddr1,
      string Original_PAddr2,
      string Original_PAddr3,
      string Original_PCity,
      string Original_PHouseType,
      string Original_PLandMark,
      string Original_PNo,
      string Original_POwnership,
      string Original_PPincode,
      string Original_PState,
      string Original_PanCard,
      string Original_Passport,
      string Original_Religion,
      string Original_State,
      string Original_VoterId)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) 0;
      this.Adapter.DeleteCommand.Parameters[1].Value = (object) Original_ID;
      if (Original_CID == null)
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) Original_CID;
      if (Original_CName == null)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_CName;
      }
      if (Original_CPhone == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_CPhone;
      }
      if (Original_CCell == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_CCell;
      }
      if (Original_CNo == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_CNo;
      }
      if (Original_CAddr1 == null)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_CAddr1;
      }
      if (Original_CAddr2 == null)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_CAddr2;
      }
      if (Original_CAddr3 == null)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_CAddr3;
      }
      if (Original_CCity == null)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_CCity;
      }
      if (Original_CPincode == null)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_CPincode;
      }
      if (Original_CIntroducer == null)
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) Original_CIntroducer;
      }
      if (Original_CAadharNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) Original_CAadharNumber;
      }
      if (Original_COtherProof == null)
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) Original_COtherProof;
      }
      if (Original_CRationCard == null)
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) Original_CRationCard;
      }
      if (Original_CInterestRate == null)
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) Original_CInterestRate;
      }
      if (Original_CEmail == null)
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) Original_CEmail;
      }
      if (Original_CImagePath == null)
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) Original_CImagePath;
      }
      if (Original_CNotes == null)
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) Original_CNotes;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[37].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[38].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[37].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[38].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[39].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[40].Value = (object) Original_CreatedOn.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[39].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[40].Value = (object) DBNull.Value;
      }
      if (Original_FatherName == null)
      {
        this.Adapter.DeleteCommand.Parameters[41].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[42].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[41].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[42].Value = (object) Original_FatherName;
      }
      if (Original_MotherName == null)
      {
        this.Adapter.DeleteCommand.Parameters[43].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[44].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[43].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[44].Value = (object) Original_MotherName;
      }
      if (Original_SpouseName == null)
      {
        this.Adapter.DeleteCommand.Parameters[45].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[46].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[45].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[46].Value = (object) Original_SpouseName;
      }
      if (Original_Sex == null)
      {
        this.Adapter.DeleteCommand.Parameters[47].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[48].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[47].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[48].Value = (object) Original_Sex;
      }
      if (Original_SampleNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[49].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[50].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[49].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[50].Value = (object) Original_SampleNumber;
      }
      if (Original_ImageFile == null)
      {
        this.Adapter.DeleteCommand.Parameters[51].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[52].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[51].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[52].Value = (object) Original_ImageFile;
      }
      if (Original_FingerNumber.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[53].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[54].Value = (object) Original_FingerNumber.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[53].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[54].Value = (object) DBNull.Value;
      }
      if (Original_IdCardIssued == null)
      {
        this.Adapter.DeleteCommand.Parameters[55].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[56].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[55].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[56].Value = (object) Original_IdCardIssued;
      }
      if (Original_BankCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[57].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[58].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[57].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[58].Value = (object) Original_BankCode;
      }
      if (Original_Dob.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[59].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[60].Value = (object) Original_Dob.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[59].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[60].Value = (object) DBNull.Value;
      }
      if (Original_DrivingLicense == null)
      {
        this.Adapter.DeleteCommand.Parameters[61].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[62].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[61].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[62].Value = (object) Original_DrivingLicense;
      }
      if (Original_Education == null)
      {
        this.Adapter.DeleteCommand.Parameters[63].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[64].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[63].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[64].Value = (object) Original_Education;
      }
      if (Original_HouseType == null)
      {
        this.Adapter.DeleteCommand.Parameters[65].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[66].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[65].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[66].Value = (object) Original_HouseType;
      }
      if (Original_Landmark == null)
      {
        this.Adapter.DeleteCommand.Parameters[67].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[68].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[67].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[68].Value = (object) Original_Landmark;
      }
      if (Original_MaritalStatus == null)
      {
        this.Adapter.DeleteCommand.Parameters[69].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[70].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[69].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[70].Value = (object) Original_MaritalStatus;
      }
      if (Original_Occupation == null)
      {
        this.Adapter.DeleteCommand.Parameters[71].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[72].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[71].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[72].Value = (object) Original_Occupation;
      }
      if (Original_OwnerShip == null)
      {
        this.Adapter.DeleteCommand.Parameters[73].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[74].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[73].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[74].Value = (object) Original_OwnerShip;
      }
      if (Original_PAddr1 == null)
      {
        this.Adapter.DeleteCommand.Parameters[75].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[76].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[75].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[76].Value = (object) Original_PAddr1;
      }
      if (Original_PAddr2 == null)
      {
        this.Adapter.DeleteCommand.Parameters[77].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[78].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[77].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[78].Value = (object) Original_PAddr2;
      }
      if (Original_PAddr3 == null)
      {
        this.Adapter.DeleteCommand.Parameters[79].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[80].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[79].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[80].Value = (object) Original_PAddr3;
      }
      if (Original_PCity == null)
      {
        this.Adapter.DeleteCommand.Parameters[81].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[82].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[81].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[82].Value = (object) Original_PCity;
      }
      if (Original_PHouseType == null)
      {
        this.Adapter.DeleteCommand.Parameters[83].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[84].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[83].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[84].Value = (object) Original_PHouseType;
      }
      if (Original_PLandMark == null)
      {
        this.Adapter.DeleteCommand.Parameters[85].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[86].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[85].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[86].Value = (object) Original_PLandMark;
      }
      if (Original_PNo == null)
      {
        this.Adapter.DeleteCommand.Parameters[87].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[88].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[87].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[88].Value = (object) Original_PNo;
      }
      if (Original_POwnership == null)
      {
        this.Adapter.DeleteCommand.Parameters[89].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[90].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[89].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[90].Value = (object) Original_POwnership;
      }
      if (Original_PPincode == null)
      {
        this.Adapter.DeleteCommand.Parameters[91].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[92].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[91].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[92].Value = (object) Original_PPincode;
      }
      if (Original_PState == null)
      {
        this.Adapter.DeleteCommand.Parameters[93].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[94].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[93].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[94].Value = (object) Original_PState;
      }
      if (Original_PanCard == null)
      {
        this.Adapter.DeleteCommand.Parameters[95].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[96].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[95].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[96].Value = (object) Original_PanCard;
      }
      if (Original_Passport == null)
      {
        this.Adapter.DeleteCommand.Parameters[97].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[98].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[97].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[98].Value = (object) Original_Passport;
      }
      if (Original_Religion == null)
      {
        this.Adapter.DeleteCommand.Parameters[99].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[100].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[99].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[100].Value = (object) Original_Religion;
      }
      if (Original_State == null)
      {
        this.Adapter.DeleteCommand.Parameters[101].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[102].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[101].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[102].Value = (object) Original_State;
      }
      if (Original_VoterId == null)
      {
        this.Adapter.DeleteCommand.Parameters[103].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[104].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[103].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[104].Value = (object) Original_VoterId;
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
      string CID,
      string CName,
      string CPhone,
      string CCell,
      string CNo,
      string CAddr1,
      string CAddr2,
      string CAddr3,
      string CCity,
      string CPincode,
      string CIntroducer,
      string CAadharNumber,
      string COtherProof,
      string CRationCard,
      string CInterestRate,
      string CEmail,
      string CImagePath,
      string CNotes,
      string CreatedBy,
      DateTime? CreatedOn,
      string FatherName,
      string MotherName,
      string SpouseName,
      string Sex,
      string FingerPrint,
      string SampleNumber,
      string ImageFile,
      int? FingerNumber,
      string IdCardIssued,
      string BankCode,
      DateTime? Dob,
      string DrivingLicense,
      string Education,
      string HouseType,
      string Landmark,
      string MaritalStatus,
      string Occupation,
      string OwnerShip,
      string PAddr1,
      string PAddr2,
      string PAddr3,
      string PCity,
      string PHouseType,
      string PLandMark,
      string PNo,
      string POwnership,
      string PPincode,
      string PState,
      string PanCard,
      string Passport,
      string Religion,
      string State,
      string VoterId)
    {
      if (CID == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) CID;
      if (CName == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) CName;
      if (CPhone == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) CPhone;
      if (CCell == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) CCell;
      if (CNo == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) CNo;
      if (CAddr1 == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) CAddr1;
      if (CAddr2 == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) CAddr2;
      if (CAddr3 == null)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) CAddr3;
      if (CCity == null)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) CCity;
      if (CPincode == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) CPincode;
      if (CIntroducer == null)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) CIntroducer;
      if (CAadharNumber == null)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) CAadharNumber;
      if (COtherProof == null)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) COtherProof;
      if (CRationCard == null)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) CRationCard;
      if (CInterestRate == null)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) CInterestRate;
      if (CEmail == null)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) CEmail;
      if (CImagePath == null)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) CImagePath;
      if (CNotes == null)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) CNotes;
      if (CreatedBy == null)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) CreatedBy;
      if (CreatedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[19].Value = (object) CreatedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[19].Value = (object) DBNull.Value;
      if (FatherName == null)
        this.Adapter.InsertCommand.Parameters[20].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[20].Value = (object) FatherName;
      if (MotherName == null)
        this.Adapter.InsertCommand.Parameters[21].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[21].Value = (object) MotherName;
      if (SpouseName == null)
        this.Adapter.InsertCommand.Parameters[22].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[22].Value = (object) SpouseName;
      if (Sex == null)
        this.Adapter.InsertCommand.Parameters[23].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[23].Value = (object) Sex;
      if (FingerPrint == null)
        this.Adapter.InsertCommand.Parameters[24].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[24].Value = (object) FingerPrint;
      if (SampleNumber == null)
        this.Adapter.InsertCommand.Parameters[25].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[25].Value = (object) SampleNumber;
      if (ImageFile == null)
        this.Adapter.InsertCommand.Parameters[26].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[26].Value = (object) ImageFile;
      if (FingerNumber.HasValue)
        this.Adapter.InsertCommand.Parameters[27].Value = (object) FingerNumber.Value;
      else
        this.Adapter.InsertCommand.Parameters[27].Value = (object) DBNull.Value;
      if (IdCardIssued == null)
        this.Adapter.InsertCommand.Parameters[28].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[28].Value = (object) IdCardIssued;
      if (BankCode == null)
        this.Adapter.InsertCommand.Parameters[29].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[29].Value = (object) BankCode;
      if (Dob.HasValue)
        this.Adapter.InsertCommand.Parameters[30].Value = (object) Dob.Value;
      else
        this.Adapter.InsertCommand.Parameters[30].Value = (object) DBNull.Value;
      if (DrivingLicense == null)
        this.Adapter.InsertCommand.Parameters[31].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[31].Value = (object) DrivingLicense;
      if (Education == null)
        this.Adapter.InsertCommand.Parameters[32].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[32].Value = (object) Education;
      if (HouseType == null)
        this.Adapter.InsertCommand.Parameters[33].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[33].Value = (object) HouseType;
      if (Landmark == null)
        this.Adapter.InsertCommand.Parameters[34].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[34].Value = (object) Landmark;
      if (MaritalStatus == null)
        this.Adapter.InsertCommand.Parameters[35].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[35].Value = (object) MaritalStatus;
      if (Occupation == null)
        this.Adapter.InsertCommand.Parameters[36].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[36].Value = (object) Occupation;
      if (OwnerShip == null)
        this.Adapter.InsertCommand.Parameters[37].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[37].Value = (object) OwnerShip;
      if (PAddr1 == null)
        this.Adapter.InsertCommand.Parameters[38].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[38].Value = (object) PAddr1;
      if (PAddr2 == null)
        this.Adapter.InsertCommand.Parameters[39].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[39].Value = (object) PAddr2;
      if (PAddr3 == null)
        this.Adapter.InsertCommand.Parameters[40].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[40].Value = (object) PAddr3;
      if (PCity == null)
        this.Adapter.InsertCommand.Parameters[41].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[41].Value = (object) PCity;
      if (PHouseType == null)
        this.Adapter.InsertCommand.Parameters[42].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[42].Value = (object) PHouseType;
      if (PLandMark == null)
        this.Adapter.InsertCommand.Parameters[43].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[43].Value = (object) PLandMark;
      if (PNo == null)
        this.Adapter.InsertCommand.Parameters[44].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[44].Value = (object) PNo;
      if (POwnership == null)
        this.Adapter.InsertCommand.Parameters[45].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[45].Value = (object) POwnership;
      if (PPincode == null)
        this.Adapter.InsertCommand.Parameters[46].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[46].Value = (object) PPincode;
      if (PState == null)
        this.Adapter.InsertCommand.Parameters[47].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[47].Value = (object) PState;
      if (PanCard == null)
        this.Adapter.InsertCommand.Parameters[48].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[48].Value = (object) PanCard;
      if (Passport == null)
        this.Adapter.InsertCommand.Parameters[49].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[49].Value = (object) Passport;
      if (Religion == null)
        this.Adapter.InsertCommand.Parameters[50].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[50].Value = (object) Religion;
      if (State == null)
        this.Adapter.InsertCommand.Parameters[51].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[51].Value = (object) State;
      if (VoterId == null)
        this.Adapter.InsertCommand.Parameters[52].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[52].Value = (object) VoterId;
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
      string CID,
      string CName,
      string CPhone,
      string CCell,
      string CNo,
      string CAddr1,
      string CAddr2,
      string CAddr3,
      string CCity,
      string CPincode,
      string CIntroducer,
      string CAadharNumber,
      string COtherProof,
      string CRationCard,
      string CInterestRate,
      string CEmail,
      string CImagePath,
      string CNotes,
      string CreatedBy,
      DateTime? CreatedOn,
      string FatherName,
      string MotherName,
      string SpouseName,
      string Sex,
      string FingerPrint,
      string SampleNumber,
      string ImageFile,
      int? FingerNumber,
      string IdCardIssued,
      string BankCode,
      DateTime? Dob,
      string DrivingLicense,
      string Education,
      string HouseType,
      string Landmark,
      string MaritalStatus,
      string Occupation,
      string OwnerShip,
      string PAddr1,
      string PAddr2,
      string PAddr3,
      string PCity,
      string PHouseType,
      string PLandMark,
      string PNo,
      string POwnership,
      string PPincode,
      string PState,
      string PanCard,
      string Passport,
      string Religion,
      string State,
      string VoterId,
      int Original_ID,
      string Original_CID,
      string Original_CName,
      string Original_CPhone,
      string Original_CCell,
      string Original_CNo,
      string Original_CAddr1,
      string Original_CAddr2,
      string Original_CAddr3,
      string Original_CCity,
      string Original_CPincode,
      string Original_CIntroducer,
      string Original_CAadharNumber,
      string Original_COtherProof,
      string Original_CRationCard,
      string Original_CInterestRate,
      string Original_CEmail,
      string Original_CImagePath,
      string Original_CNotes,
      string Original_CreatedBy,
      DateTime? Original_CreatedOn,
      string Original_FatherName,
      string Original_MotherName,
      string Original_SpouseName,
      string Original_Sex,
      string Original_SampleNumber,
      string Original_ImageFile,
      int? Original_FingerNumber,
      string Original_IdCardIssued,
      string Original_BankCode,
      DateTime? Original_Dob,
      string Original_DrivingLicense,
      string Original_Education,
      string Original_HouseType,
      string Original_Landmark,
      string Original_MaritalStatus,
      string Original_Occupation,
      string Original_OwnerShip,
      string Original_PAddr1,
      string Original_PAddr2,
      string Original_PAddr3,
      string Original_PCity,
      string Original_PHouseType,
      string Original_PLandMark,
      string Original_PNo,
      string Original_POwnership,
      string Original_PPincode,
      string Original_PState,
      string Original_PanCard,
      string Original_Passport,
      string Original_Religion,
      string Original_State,
      string Original_VoterId)
    {
      if (CID == null)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) CID;
      if (CName == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) CName;
      if (CPhone == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) CPhone;
      if (CCell == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) CCell;
      if (CNo == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) CNo;
      if (CAddr1 == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) CAddr1;
      if (CAddr2 == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) CAddr2;
      if (CAddr3 == null)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) CAddr3;
      if (CCity == null)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) CCity;
      if (CPincode == null)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) CPincode;
      if (CIntroducer == null)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) CIntroducer;
      if (CAadharNumber == null)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) CAadharNumber;
      if (COtherProof == null)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) COtherProof;
      if (CRationCard == null)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) CRationCard;
      if (CInterestRate == null)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) CInterestRate;
      if (CEmail == null)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) CEmail;
      if (CImagePath == null)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) CImagePath;
      if (CNotes == null)
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) CNotes;
      if (CreatedBy == null)
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) CreatedBy;
      if (CreatedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) CreatedOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) DBNull.Value;
      if (FatherName == null)
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) FatherName;
      if (MotherName == null)
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) MotherName;
      if (SpouseName == null)
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) SpouseName;
      if (Sex == null)
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) Sex;
      if (FingerPrint == null)
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) FingerPrint;
      if (SampleNumber == null)
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) SampleNumber;
      if (ImageFile == null)
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) ImageFile;
      if (FingerNumber.HasValue)
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) FingerNumber.Value;
      else
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) DBNull.Value;
      if (IdCardIssued == null)
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) IdCardIssued;
      if (BankCode == null)
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) BankCode;
      if (Dob.HasValue)
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) Dob.Value;
      else
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) DBNull.Value;
      if (DrivingLicense == null)
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) DrivingLicense;
      if (Education == null)
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) Education;
      if (HouseType == null)
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) HouseType;
      if (Landmark == null)
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) Landmark;
      if (MaritalStatus == null)
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) MaritalStatus;
      if (Occupation == null)
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) Occupation;
      if (OwnerShip == null)
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) OwnerShip;
      if (PAddr1 == null)
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) PAddr1;
      if (PAddr2 == null)
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) PAddr2;
      if (PAddr3 == null)
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) PAddr3;
      if (PCity == null)
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) PCity;
      if (PHouseType == null)
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) PHouseType;
      if (PLandMark == null)
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) PLandMark;
      if (PNo == null)
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) PNo;
      if (POwnership == null)
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) POwnership;
      if (PPincode == null)
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) PPincode;
      if (PState == null)
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) PState;
      if (PanCard == null)
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) PanCard;
      if (Passport == null)
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) Passport;
      if (Religion == null)
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) Religion;
      if (State == null)
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) State;
      if (VoterId == null)
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) VoterId;
      this.Adapter.UpdateCommand.Parameters[53].Value = (object) 0;
      this.Adapter.UpdateCommand.Parameters[54].Value = (object) Original_ID;
      if (Original_CID == null)
        this.Adapter.UpdateCommand.Parameters[55].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[55].Value = (object) Original_CID;
      if (Original_CName == null)
      {
        this.Adapter.UpdateCommand.Parameters[56].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[57].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[56].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[57].Value = (object) Original_CName;
      }
      if (Original_CPhone == null)
      {
        this.Adapter.UpdateCommand.Parameters[58].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[59].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[58].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[59].Value = (object) Original_CPhone;
      }
      if (Original_CCell == null)
      {
        this.Adapter.UpdateCommand.Parameters[60].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[61].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[60].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[61].Value = (object) Original_CCell;
      }
      if (Original_CNo == null)
      {
        this.Adapter.UpdateCommand.Parameters[62].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[63].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[62].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[63].Value = (object) Original_CNo;
      }
      if (Original_CAddr1 == null)
      {
        this.Adapter.UpdateCommand.Parameters[64].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[65].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[64].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[65].Value = (object) Original_CAddr1;
      }
      if (Original_CAddr2 == null)
      {
        this.Adapter.UpdateCommand.Parameters[66].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[67].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[66].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[67].Value = (object) Original_CAddr2;
      }
      if (Original_CAddr3 == null)
      {
        this.Adapter.UpdateCommand.Parameters[68].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[69].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[68].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[69].Value = (object) Original_CAddr3;
      }
      if (Original_CCity == null)
      {
        this.Adapter.UpdateCommand.Parameters[70].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[71].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[70].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[71].Value = (object) Original_CCity;
      }
      if (Original_CPincode == null)
      {
        this.Adapter.UpdateCommand.Parameters[72].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[73].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[72].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[73].Value = (object) Original_CPincode;
      }
      if (Original_CIntroducer == null)
      {
        this.Adapter.UpdateCommand.Parameters[74].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[75].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[74].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[75].Value = (object) Original_CIntroducer;
      }
      if (Original_CAadharNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[76].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[77].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[76].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[77].Value = (object) Original_CAadharNumber;
      }
      if (Original_COtherProof == null)
      {
        this.Adapter.UpdateCommand.Parameters[78].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[79].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[78].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[79].Value = (object) Original_COtherProof;
      }
      if (Original_CRationCard == null)
      {
        this.Adapter.UpdateCommand.Parameters[80].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[81].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[80].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[81].Value = (object) Original_CRationCard;
      }
      if (Original_CInterestRate == null)
      {
        this.Adapter.UpdateCommand.Parameters[82].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[83].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[82].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[83].Value = (object) Original_CInterestRate;
      }
      if (Original_CEmail == null)
      {
        this.Adapter.UpdateCommand.Parameters[84].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[85].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[84].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[85].Value = (object) Original_CEmail;
      }
      if (Original_CImagePath == null)
      {
        this.Adapter.UpdateCommand.Parameters[86].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[87].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[86].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[87].Value = (object) Original_CImagePath;
      }
      if (Original_CNotes == null)
      {
        this.Adapter.UpdateCommand.Parameters[88].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[89].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[88].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[89].Value = (object) Original_CNotes;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[90].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[91].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[90].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[91].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[92].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[93].Value = (object) Original_CreatedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[92].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[93].Value = (object) DBNull.Value;
      }
      if (Original_FatherName == null)
      {
        this.Adapter.UpdateCommand.Parameters[94].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[95].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[94].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[95].Value = (object) Original_FatherName;
      }
      if (Original_MotherName == null)
      {
        this.Adapter.UpdateCommand.Parameters[96].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[97].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[96].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[97].Value = (object) Original_MotherName;
      }
      if (Original_SpouseName == null)
      {
        this.Adapter.UpdateCommand.Parameters[98].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[99].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[98].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[99].Value = (object) Original_SpouseName;
      }
      if (Original_Sex == null)
      {
        this.Adapter.UpdateCommand.Parameters[100].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[101].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[100].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[101].Value = (object) Original_Sex;
      }
      if (Original_SampleNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[102].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[103].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[102].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[103].Value = (object) Original_SampleNumber;
      }
      if (Original_ImageFile == null)
      {
        this.Adapter.UpdateCommand.Parameters[104].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[105].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[104].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[105].Value = (object) Original_ImageFile;
      }
      if (Original_FingerNumber.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[106].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[107].Value = (object) Original_FingerNumber.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[106].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[107].Value = (object) DBNull.Value;
      }
      if (Original_IdCardIssued == null)
      {
        this.Adapter.UpdateCommand.Parameters[108].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[109].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[108].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[109].Value = (object) Original_IdCardIssued;
      }
      if (Original_BankCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[110].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[111].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[110].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[111].Value = (object) Original_BankCode;
      }
      if (Original_Dob.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[112].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[113].Value = (object) Original_Dob.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[112].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[113].Value = (object) DBNull.Value;
      }
      if (Original_DrivingLicense == null)
      {
        this.Adapter.UpdateCommand.Parameters[114].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[115].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[114].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[115].Value = (object) Original_DrivingLicense;
      }
      if (Original_Education == null)
      {
        this.Adapter.UpdateCommand.Parameters[116].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[117].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[116].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[117].Value = (object) Original_Education;
      }
      if (Original_HouseType == null)
      {
        this.Adapter.UpdateCommand.Parameters[118].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[119].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[118].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[119].Value = (object) Original_HouseType;
      }
      if (Original_Landmark == null)
      {
        this.Adapter.UpdateCommand.Parameters[120].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[121].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[120].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[121].Value = (object) Original_Landmark;
      }
      if (Original_MaritalStatus == null)
      {
        this.Adapter.UpdateCommand.Parameters[122].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[123].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[122].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[123].Value = (object) Original_MaritalStatus;
      }
      if (Original_Occupation == null)
      {
        this.Adapter.UpdateCommand.Parameters[124].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[125].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[124].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[125].Value = (object) Original_Occupation;
      }
      if (Original_OwnerShip == null)
      {
        this.Adapter.UpdateCommand.Parameters[126].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[(int) sbyte.MaxValue].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[126].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[(int) sbyte.MaxValue].Value = (object) Original_OwnerShip;
      }
      if (Original_PAddr1 == null)
      {
        this.Adapter.UpdateCommand.Parameters[128].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[129].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[128].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[129].Value = (object) Original_PAddr1;
      }
      if (Original_PAddr2 == null)
      {
        this.Adapter.UpdateCommand.Parameters[130].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[131].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[130].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[131].Value = (object) Original_PAddr2;
      }
      if (Original_PAddr3 == null)
      {
        this.Adapter.UpdateCommand.Parameters[132].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[133].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[132].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[133].Value = (object) Original_PAddr3;
      }
      if (Original_PCity == null)
      {
        this.Adapter.UpdateCommand.Parameters[134].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[135].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[134].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[135].Value = (object) Original_PCity;
      }
      if (Original_PHouseType == null)
      {
        this.Adapter.UpdateCommand.Parameters[136].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[137].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[136].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[137].Value = (object) Original_PHouseType;
      }
      if (Original_PLandMark == null)
      {
        this.Adapter.UpdateCommand.Parameters[138].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[139].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[138].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[139].Value = (object) Original_PLandMark;
      }
      if (Original_PNo == null)
      {
        this.Adapter.UpdateCommand.Parameters[140].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[141].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[140].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[141].Value = (object) Original_PNo;
      }
      if (Original_POwnership == null)
      {
        this.Adapter.UpdateCommand.Parameters[142].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[143].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[142].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[143].Value = (object) Original_POwnership;
      }
      if (Original_PPincode == null)
      {
        this.Adapter.UpdateCommand.Parameters[144].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[145].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[144].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[145].Value = (object) Original_PPincode;
      }
      if (Original_PState == null)
      {
        this.Adapter.UpdateCommand.Parameters[146].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[147].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[146].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[147].Value = (object) Original_PState;
      }
      if (Original_PanCard == null)
      {
        this.Adapter.UpdateCommand.Parameters[148].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[149].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[148].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[149].Value = (object) Original_PanCard;
      }
      if (Original_Passport == null)
      {
        this.Adapter.UpdateCommand.Parameters[150].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[151].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[150].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[151].Value = (object) Original_Passport;
      }
      if (Original_Religion == null)
      {
        this.Adapter.UpdateCommand.Parameters[152].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[153].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[152].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[153].Value = (object) Original_Religion;
      }
      if (Original_State == null)
      {
        this.Adapter.UpdateCommand.Parameters[154].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[155].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[154].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[155].Value = (object) Original_State;
      }
      if (Original_VoterId == null)
      {
        this.Adapter.UpdateCommand.Parameters[156].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[157].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[156].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[157].Value = (object) Original_VoterId;
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

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public virtual int Update(
      string CName,
      string CPhone,
      string CCell,
      string CNo,
      string CAddr1,
      string CAddr2,
      string CAddr3,
      string CCity,
      string CPincode,
      string CIntroducer,
      string CAadharNumber,
      string COtherProof,
      string CRationCard,
      string CInterestRate,
      string CEmail,
      string CImagePath,
      string CNotes,
      string CreatedBy,
      DateTime? CreatedOn,
      string FatherName,
      string MotherName,
      string SpouseName,
      string Sex,
      string FingerPrint,
      string SampleNumber,
      string ImageFile,
      int? FingerNumber,
      string IdCardIssued,
      string BankCode,
      DateTime? Dob,
      string DrivingLicense,
      string Education,
      string HouseType,
      string Landmark,
      string MaritalStatus,
      string Occupation,
      string OwnerShip,
      string PAddr1,
      string PAddr2,
      string PAddr3,
      string PCity,
      string PHouseType,
      string PLandMark,
      string PNo,
      string POwnership,
      string PPincode,
      string PState,
      string PanCard,
      string Passport,
      string Religion,
      string State,
      string VoterId,
      int Original_ID,
      string Original_CID,
      string Original_CName,
      string Original_CPhone,
      string Original_CCell,
      string Original_CNo,
      string Original_CAddr1,
      string Original_CAddr2,
      string Original_CAddr3,
      string Original_CCity,
      string Original_CPincode,
      string Original_CIntroducer,
      string Original_CAadharNumber,
      string Original_COtherProof,
      string Original_CRationCard,
      string Original_CInterestRate,
      string Original_CEmail,
      string Original_CImagePath,
      string Original_CNotes,
      string Original_CreatedBy,
      DateTime? Original_CreatedOn,
      string Original_FatherName,
      string Original_MotherName,
      string Original_SpouseName,
      string Original_Sex,
      string Original_SampleNumber,
      string Original_ImageFile,
      int? Original_FingerNumber,
      string Original_IdCardIssued,
      string Original_BankCode,
      DateTime? Original_Dob,
      string Original_DrivingLicense,
      string Original_Education,
      string Original_HouseType,
      string Original_Landmark,
      string Original_MaritalStatus,
      string Original_Occupation,
      string Original_OwnerShip,
      string Original_PAddr1,
      string Original_PAddr2,
      string Original_PAddr3,
      string Original_PCity,
      string Original_PHouseType,
      string Original_PLandMark,
      string Original_PNo,
      string Original_POwnership,
      string Original_PPincode,
      string Original_PState,
      string Original_PanCard,
      string Original_Passport,
      string Original_Religion,
      string Original_State,
      string Original_VoterId)
    {
      return this.Update(Original_CID, CName, CPhone, CCell, CNo, CAddr1, CAddr2, CAddr3, CCity, CPincode, CIntroducer, CAadharNumber, COtherProof, CRationCard, CInterestRate, CEmail, CImagePath, CNotes, CreatedBy, CreatedOn, FatherName, MotherName, SpouseName, Sex, FingerPrint, SampleNumber, ImageFile, FingerNumber, IdCardIssued, BankCode, Dob, DrivingLicense, Education, HouseType, Landmark, MaritalStatus, Occupation, OwnerShip, PAddr1, PAddr2, PAddr3, PCity, PHouseType, PLandMark, PNo, POwnership, PPincode, PState, PanCard, Passport, Religion, State, VoterId, Original_ID, Original_CID, Original_CName, Original_CPhone, Original_CCell, Original_CNo, Original_CAddr1, Original_CAddr2, Original_CAddr3, Original_CCity, Original_CPincode, Original_CIntroducer, Original_CAadharNumber, Original_COtherProof, Original_CRationCard, Original_CInterestRate, Original_CEmail, Original_CImagePath, Original_CNotes, Original_CreatedBy, Original_CreatedOn, Original_FatherName, Original_MotherName, Original_SpouseName, Original_Sex, Original_SampleNumber, Original_ImageFile, Original_FingerNumber, Original_IdCardIssued, Original_BankCode, Original_Dob, Original_DrivingLicense, Original_Education, Original_HouseType, Original_Landmark, Original_MaritalStatus, Original_Occupation, Original_OwnerShip, Original_PAddr1, Original_PAddr2, Original_PAddr3, Original_PCity, Original_PHouseType, Original_PLandMark, Original_PNo, Original_POwnership, Original_PPincode, Original_PState, Original_PanCard, Original_Passport, Original_Religion, Original_State, Original_VoterId);
    }
  }
}
