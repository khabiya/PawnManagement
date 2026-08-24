
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class CustomersClass
  {
    public static List<string> getDistinctValuesOfThisColumn(string colName)
    {
      string strError = "";
      List<string> valuesOfThisColumn = new List<string>();
      string my_querry = "Select distinct    " + colName + " from tblCustomers";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          valuesOfThisColumn.Add(row[colName].ToString());
      }
      return valuesOfThisColumn;
    }

    public static List<string> getDistinctYears()
    {
      string strError = "";
      List<string> distinctYears = new List<string>();
      string my_querry = "select distinct(year(createdon))  as distinctyears from tblcustomers";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          distinctYears.Add(row["DistinctYears"].ToString());
      }
      return distinctYears;
    }

    public static bool checkifCustomerAlreadyExists(string CustomerCode)
    {
      string strError = "";
      string my_querry = "select * from tblcustomers where Cid = @Cid";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Cid", (object) CustomerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form add customer.checkIfCustomerAlreadyAdded", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static bool checkifThisValueExistsInThisColumn(string strColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblcustomers where " + strColumnName + "=@" + strColumnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(strColumnName, (object) strValue));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form add customer.checkIfCustomerAlreadyAdded", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string getNextCustomerCode(char c)
    {
      DataTable dataTable1 = new DataTable();
      string strError = "";
      DataTable dataTable2 = SQLHelper.GetDataTable("select * from tblCustomers where CID like '" + c.ToString() + "%' order by createdOn desc", ref strError);
      if (dataTable2 == null)
        return "";
      if (dataTable2 == null || dataTable2.Rows.Count <= 0)
        return c.ToString() + "1";
      return c.ToString() + CustomersClass.NextCustomerCode(dataTable2);
    }

    public static string NextCustomerCode(DataTable dtCustomerId)
    {
      List<int> intList = new List<int>();
      if (dtCustomerId != null && dtCustomerId.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dtCustomerId.Rows)
          intList.Add(int.Parse(row["cid"].ToString().Substring(1)));
      }
      intList.Sort();
      IEnumerable<int> source = Enumerable.Range(1, intList.Max()).Except<int>((IEnumerable<int>) intList);
      return source.Count<int>() > 0 ? source.ElementAt<int>(0).ToString() : (intList.Max() + 1).ToString();
    }

    public static DataTable getCustomerDetails(string customerCode)
    {
      string strError = "";
      string my_querry = "Select * from tblCustomers where CID = @Cid";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Cid", (object) customerCode));
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static string getName(string customerCode)
    {
      string strError = "";
      string my_querry = "Select * from tblCustomers where CID = @Cid";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Cid", (object) customerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["CName"].ToString() : "";
    }

    public static string getSex(string customerCode)
    {
      string strError = "";
      string my_querry = "Select * from tblCustomers where CID = @Cid";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Cid", (object) customerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["Sex"].ToString() : "";
    }

    public static string getCustomerCode(string ID)
    {
      string strError = "";
      string my_querry = "Select * from tblCustomers where ID = @ID";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (ID), (object) ID));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["Cid"].ToString() : "";
    }

    public static string getId(string CustomerCode)
    {
      string strError = "";
      string my_querry = "Select * from tblCustomers where CID = @CID";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("CID", (object) CustomerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["ID"].ToString() : "";
    }

    public static string updateRelation(string RelationName, string customerCode, string value)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("update tblCustomers set " + RelationName + "=@" + RelationName + " where CID=@CID", new List<OleDbParameter>()
      {
        new OleDbParameter(RelationName, (object) value),
        new OleDbParameter("Cid", (object) customerCode)
      }, ref strError);
    }

    public static int getMaxId()
    {
      string strError = "";
      string my_querry = "Select max(ID) AS ID from  tblCustomers ";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 ? int.Parse(dataTable2.Rows[0]["ID"].ToString()) + 1 : 1;
    }

    public static string SaveNewWithFingerPrint(
      string customerCode,
      string CustomerName,
      string Dob,
      string Sex,
      string CPhone,
      string AlternateNumber,
      string Notes,
      string EmaildId,
      string Occupation,
      string Fathername,
      string MotherName,
      string SpouseName,
      string IntroducedBy,
      string MaritalStatus,
      string Education,
      string Religion,
      string InterestRate,
      string CNo,
      string CAddr1,
      string Caddr2,
      string CAddr3,
      string City,
      string Pincode,
      string Landmark,
      string HouseType,
      string OwnerShip,
      string pCNo,
      string pCAddr1,
      string pCaddr2,
      string pCAddr3,
      string pCity,
      string pPincode,
      string pLandmark,
      string pHouseType,
      string pOwnerShip,
      string AadharNumber,
      string PanCard,
      string VoterId,
      string DrivingLicense,
      string RationCard,
      string Others,
      string CreatedBy,
      string CreatedOn,
      byte[] minData,
      int FingerNumber,
      int SampleNumber)
    {
      string strError = "";
      string base64String = Convert.ToBase64String(minData);
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("CID", (object) customerCode));
      parameters.Add(new OleDbParameter("CName", (object) CustomerName));
      if (Dob == "")
        parameters.Add(new OleDbParameter(nameof (Dob), (object) DBNull.Value));
      else
        parameters.Add(new OleDbParameter(nameof (Dob), (object) Dob));
      parameters.Add(new OleDbParameter(nameof (Sex), (object) Sex));
      parameters.Add(new OleDbParameter(nameof (CPhone), (object) CPhone));
      parameters.Add(new OleDbParameter("CCell", (object) AlternateNumber));
      parameters.Add(new OleDbParameter("CNotes", (object) Notes));
      parameters.Add(new OleDbParameter("CEmail", (object) EmaildId));
      parameters.Add(new OleDbParameter(nameof (Occupation), (object) Occupation));
      parameters.Add(new OleDbParameter("FatherName", (object) Fathername));
      parameters.Add(new OleDbParameter(nameof (MotherName), (object) MotherName));
      parameters.Add(new OleDbParameter("Spousename", (object) SpouseName));
      parameters.Add(new OleDbParameter(nameof (IntroducedBy), (object) IntroducedBy));
      parameters.Add(new OleDbParameter(nameof (MaritalStatus), (object) MaritalStatus));
      parameters.Add(new OleDbParameter(nameof (Education), (object) Education));
      parameters.Add(new OleDbParameter(nameof (Religion), (object) Religion));
      parameters.Add(new OleDbParameter(nameof (InterestRate), (object) InterestRate));
      parameters.Add(new OleDbParameter(nameof (CNo), (object) CNo));
      parameters.Add(new OleDbParameter(nameof (CAddr1), (object) CAddr1));
      parameters.Add(new OleDbParameter("CAddr2", (object) Caddr2));
      parameters.Add(new OleDbParameter(nameof (CAddr3), (object) CAddr3));
      parameters.Add(new OleDbParameter("CCity", (object) City));
      parameters.Add(new OleDbParameter("CPinCode", (object) Pincode));
      parameters.Add(new OleDbParameter("LandMark", (object) Landmark));
      parameters.Add(new OleDbParameter(nameof (HouseType), (object) HouseType));
      parameters.Add(new OleDbParameter(nameof (OwnerShip), (object) OwnerShip));
      parameters.Add(new OleDbParameter(nameof (pCNo), (object) pCNo));
      parameters.Add(new OleDbParameter(nameof (pCAddr1), (object) pCAddr1));
      parameters.Add(new OleDbParameter("pCAddr2", (object) pCaddr2));
      parameters.Add(new OleDbParameter(nameof (pCAddr3), (object) pCAddr3));
      parameters.Add(new OleDbParameter("pCCity", (object) pCity));
      parameters.Add(new OleDbParameter("pCPinCode", (object) pPincode));
      parameters.Add(new OleDbParameter("pLandMark", (object) pLandmark));
      parameters.Add(new OleDbParameter(nameof (pHouseType), (object) pHouseType));
      parameters.Add(new OleDbParameter(nameof (pOwnerShip), (object) pOwnerShip));
      parameters.Add(new OleDbParameter("CAadharNumber", (object) AadharNumber));
      parameters.Add(new OleDbParameter(nameof (PanCard), (object) PanCard));
      parameters.Add(new OleDbParameter(nameof (VoterId), (object) VoterId));
      parameters.Add(new OleDbParameter(nameof (DrivingLicense), (object) DrivingLicense));
      parameters.Add(new OleDbParameter("CRationCard", (object) RationCard));
      parameters.Add(new OleDbParameter("COtherProof", (object) Others));
      parameters.Add(new OleDbParameter(nameof (CreatedBy), (object) CreatedBy));
      parameters.Add(new OleDbParameter(nameof (CreatedOn), (object) CreatedOn));
      parameters.Add(new OleDbParameter(nameof (FingerNumber), (object) FingerNumber));
      parameters.Add(new OleDbParameter(nameof (SampleNumber), (object) SampleNumber));
      parameters.Add(new OleDbParameter("FingerPrint", (object) base64String));
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("insert into tblCustomers(CId,  CName, Dob, Sex, CPhone, CCell, cNotes, cEmail,Occupation,  Fathername ,  MotherName,  SpouseName,  cintroducer,  MaritalStatus, Education, Religion,             cInterestRate,  CNo,  CAddr1,  Caddr2,  CAddr3,  cCity,  cPincode, Landmark, HouseType , OwnerShip,              pNo,  pAddr1,  paddr2,  pAddr3,  pCity,  pPincode,  pLandmark,  pHouseType,  pOwnerShip,              CAadharNumber, PanCard, VoterId, DrivingLicense, cRationCard, COtherProof, CreatedBy,  CreatedOn,FingerNumber,SampleNumber,FingerPrint) values (@CId,@CName,@Dob,@Sex,@CPhone,@CCell,@cNotes,@cEmail,Occupation,@Fathername,@MotherName,@SpouseName,@cintroducer,@MaritalStatus,@Education,@Religion,@cInterestRate,@CNo,@CAddr1,@Caddr2,@CAddr3,@cCity,@cPincode,@Landmark,@HouseType,@OwnerShip,@pNo,@pAddr1,@paddr2,@pAddr3,@pCity,@pPincode,@pLandmark,@pHouseType,@pOwnerShip,@cAadharNumber,@PanCard,@VoterId,@DrivingLicense,@cRationCard,@OtherProof,@CreatedBy,@CreatedOn,@FingerNumber,@SampleNumber,@FingerPrint)", parameters, ref strError);
    }

    public static string SaveNew(
      string customerCode,
      string CustomerName,
      string Dob,
      string Sex,
      string CPhone,
      string AlternateNumber,
      string Notes,
      string EmaildId,
      string Occupation,
      string Fathername,
      string MotherName,
      string SpouseName,
      string IntroducedBy,
      string MaritalStatus,
      string Education,
      string Religion,
      string InterestRate,
      string CNo,
      string CAddr1,
      string Caddr2,
      string CAddr3,
      string City,
      string Pincode,
      string Landmark,
      string HouseType,
      string OwnerShip,
      string pCNo,
      string pCAddr1,
      string pCaddr2,
      string pCAddr3,
      string pCity,
      string pPincode,
      string pLandmark,
      string pHouseType,
      string pOwnerShip,
      string AadharNumber,
      string PanCard,
      string VoterId,
      string DrivingLicense,
      string RationCard,
      string Others,
      string CreatedBy,
      string CreatedOn)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("CID", (object) customerCode));
      parameters.Add(new OleDbParameter("CName", (object) CustomerName));
      if (Dob == "")
        parameters.Add(new OleDbParameter(nameof (Dob), (object) DBNull.Value));
      else
        parameters.Add(new OleDbParameter(nameof (Dob), (object) Dob));
      parameters.Add(new OleDbParameter(nameof (Sex), (object) Sex));
      parameters.Add(new OleDbParameter(nameof (CPhone), (object) CPhone));
      parameters.Add(new OleDbParameter("CCell", (object) AlternateNumber));
      parameters.Add(new OleDbParameter("CNotes", (object) Notes));
      parameters.Add(new OleDbParameter("CEmail", (object) EmaildId));
      parameters.Add(new OleDbParameter(nameof (Occupation), (object) Occupation));
      parameters.Add(new OleDbParameter("FatherName", (object) Fathername));
      parameters.Add(new OleDbParameter(nameof (MotherName), (object) MotherName));
      parameters.Add(new OleDbParameter("Spousename", (object) SpouseName));
      parameters.Add(new OleDbParameter(nameof (IntroducedBy), (object) IntroducedBy));
      parameters.Add(new OleDbParameter(nameof (MaritalStatus), (object) MaritalStatus));
      parameters.Add(new OleDbParameter(nameof (Education), (object) Education));
      parameters.Add(new OleDbParameter(nameof (Religion), (object) Religion));
      parameters.Add(new OleDbParameter(nameof (InterestRate), (object) InterestRate));
      parameters.Add(new OleDbParameter(nameof (CNo), (object) CNo));
      parameters.Add(new OleDbParameter(nameof (CAddr1), (object) CAddr1));
      parameters.Add(new OleDbParameter("CAddr2", (object) Caddr2));
      parameters.Add(new OleDbParameter(nameof (CAddr3), (object) CAddr3));
      parameters.Add(new OleDbParameter("CCity", (object) City));
      parameters.Add(new OleDbParameter("CPinCode", (object) Pincode));
      parameters.Add(new OleDbParameter("LandMark", (object) Landmark));
      parameters.Add(new OleDbParameter(nameof (HouseType), (object) HouseType));
      parameters.Add(new OleDbParameter(nameof (OwnerShip), (object) OwnerShip));
      parameters.Add(new OleDbParameter(nameof (pCNo), (object) pCNo));
      parameters.Add(new OleDbParameter(nameof (pCAddr1), (object) pCAddr1));
      parameters.Add(new OleDbParameter("pCAddr2", (object) pCaddr2));
      parameters.Add(new OleDbParameter(nameof (pCAddr3), (object) pCAddr3));
      parameters.Add(new OleDbParameter("pCCity", (object) pCity));
      parameters.Add(new OleDbParameter("pCPinCode", (object) pPincode));
      parameters.Add(new OleDbParameter("pLandMark", (object) pLandmark));
      parameters.Add(new OleDbParameter(nameof (pHouseType), (object) pHouseType));
      parameters.Add(new OleDbParameter(nameof (pOwnerShip), (object) pOwnerShip));
      parameters.Add(new OleDbParameter("CAadharNumber", (object) AadharNumber));
      parameters.Add(new OleDbParameter(nameof (PanCard), (object) PanCard));
      parameters.Add(new OleDbParameter(nameof (VoterId), (object) VoterId));
      parameters.Add(new OleDbParameter(nameof (DrivingLicense), (object) DrivingLicense));
      parameters.Add(new OleDbParameter("CRationCard", (object) RationCard));
      parameters.Add(new OleDbParameter("COtherProof", (object) Others));
      parameters.Add(new OleDbParameter(nameof (CreatedBy), (object) CreatedBy));
      parameters.Add(new OleDbParameter(nameof (CreatedOn), (object) CreatedOn));
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("insert into tblCustomers(CId,  CName, Dob, Sex, CPhone, CCell, cNotes, cEmail,Occupation,  Fathername ,  MotherName,  SpouseName,  cintroducer,  MaritalStatus, Education, Religion,             cInterestRate,  CNo,  CAddr1,  Caddr2,  CAddr3,  cCity,  cPincode, Landmark, HouseType , OwnerShip,              pNo,  pAddr1,  paddr2,  pAddr3,  pCity,  pPincode,  pLandmark,  pHouseType,  pOwnerShip,              CAadharNumber, PanCard, VoterId, DrivingLicense, cRationCard, COtherProof, CreatedBy,  CreatedOn) values (@CId,@CName,@Dob,@Sex,@CPhone,@CCell,@cNotes,@cEmail,Occupation,@Fathername,@MotherName,@SpouseName,@cintroducer,@MaritalStatus,@Education,@Religion,@cInterestRate,@CNo,@CAddr1,@Caddr2,@CAddr3,@cCity,@cPincode,@Landmark,@HouseType,@OwnerShip,@pNo,@pAddr1,@paddr2,@pAddr3,@pCity,@pPincode,@pLandmark,@pHouseType,@pOwnerShip,@cAadharNumber,@PanCard,@VoterId,@DrivingLicense,@cRationCard,@OtherProof,@CreatedBy,@CreatedOn)", parameters, ref strError);
    }

    public static string Save(
      string customerCode,
      string CustomerName,
      string Sex,
      string Fathername,
      string MotherName,
      string SpouseName,
      string CPhone,
      string AlternateNumber,
      string CNo,
      string CAddr1,
      string Caddr2,
      string CAddr3,
      string City,
      string Pincode,
      string Introducer,
      string AdharNumber,
      string OtherProof,
      string RationCard,
      string InterestRate,
      string Email,
      string Notes,
      double MonthlyIncome,
      string CreatedBy,
      string CreatedOn)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("insert into tblCustomers(CID,CName,Sex,FatherName,MotherName,SpouseName,CPhone,CCell,CNo,CAddr1,CAddr2,CAddr3,CCity,CPinCode,CIntroducer,CAadharNumber,COtherProof,CRationCard,CInterestRate,CEmail,CNotes,MonthlyIncome,CreatedBy,CreatedOn) values (@CID,@CName,@Sex,@FatherName,@MotherName,@SpouseName,@CPhone,@CCell,@CNo,@CAddr1,@CAddr2,@CAddr3,@CCity,@CPinCode,@CIntroducer,@CAadharNumber,@COtherProof,@CRationCard,@CInterestRate,@CEmail,@CNotes,@MonthlyIncome,@CreatedBy,@CreatedOn)", new List<OleDbParameter>()
      {
        new OleDbParameter("CID", (object) customerCode),
        new OleDbParameter("CName", (object) CustomerName),
        new OleDbParameter(nameof (Sex), (object) Sex),
        new OleDbParameter("FatherName", (object) Fathername),
        new OleDbParameter(nameof (MotherName), (object) MotherName),
        new OleDbParameter("Spousename", (object) SpouseName),
        new OleDbParameter(nameof (CPhone), (object) CPhone),
        new OleDbParameter("CCell", (object) AlternateNumber),
        new OleDbParameter(nameof (CNo), (object) CNo),
        new OleDbParameter(nameof (CAddr1), (object) CAddr1),
        new OleDbParameter("CAddr2", (object) Caddr2),
        new OleDbParameter(nameof (CAddr3), (object) CAddr3),
        new OleDbParameter("CCity", (object) City),
        new OleDbParameter("CPinCode", (object) Pincode),
        new OleDbParameter("CIntroducer", (object) Introducer),
        new OleDbParameter("CAadharNumber", (object) AdharNumber),
        new OleDbParameter("COtherProof", (object) OtherProof),
        new OleDbParameter("CRationCard", (object) RationCard),
        new OleDbParameter("CInterestRate", (object) InterestRate),
        new OleDbParameter("CEmail", (object) Email),
        new OleDbParameter("CNotes", (object) Notes),
        new OleDbParameter(nameof (MonthlyIncome), (object) MonthlyIncome),
        new OleDbParameter(nameof (CreatedBy), (object) CreatedBy),
        new OleDbParameter(nameof (CreatedOn), (object) CreatedOn)
      }, ref strError);
    }

    public static string saveFingerPrint(
      string customerCode,
      string CustomerName,
      string Sex,
      string Fathername,
      string MotherName,
      string SpouseName,
      string CPhone,
      string AlternateNumber,
      string CNo,
      string CAddr1,
      string Caddr2,
      string CAddr3,
      string City,
      string Pincode,
      string Introducer,
      string AdharNumber,
      string OtherProof,
      string RationCard,
      string InterestRate,
      string Email,
      string Notes,
      string CreatedBy,
      string CreatedOn,
      byte[] minData,
      int FingerNumber,
      int SampleNumber)
    {
      string strError = "";
      string base64String = Convert.ToBase64String(minData);
      return SQLHelper.RunCommand("insert into tblCustomers(CID,CName,Sex,FatherName,MotherName,SpouseName,CPhone,CCell,CNo,CAddr1,CAddr2,CAddr3,CCity,CPinCode,CIntroducer,CAadharNumber,COtherProof,CRationCard,CInterestRate,CEmail,CNotes,CreatedBy,CreatedOn,FingerNumber,SampleNumber,FingerPrint) values (@CID,@CName,@Sex,@FatherName,@MotherName,@SpouseName,@CPhone,@CCell,@CNo,@CAddr1,@CAddr2,@CAddr3,@CCity,@CPinCode,@CIntroducer,@CAadharNumber,@COtherProof,@CRationCard,@CInterestRate,@CEmail,@CNotes,@CreatedBy,@CreatedOn,@FingerNumber,@SampleNumber,@FingerPrint)", new List<OleDbParameter>()
      {
        new OleDbParameter("CID", (object) customerCode),
        new OleDbParameter("CName", (object) CustomerName),
        new OleDbParameter(nameof (Sex), (object) Sex),
        new OleDbParameter("FatherName", (object) Fathername),
        new OleDbParameter(nameof (MotherName), (object) MotherName),
        new OleDbParameter("Spousename", (object) SpouseName),
        new OleDbParameter(nameof (CPhone), (object) CPhone),
        new OleDbParameter("CCell", (object) AlternateNumber),
        new OleDbParameter(nameof (CNo), (object) CNo),
        new OleDbParameter(nameof (CAddr1), (object) CAddr1),
        new OleDbParameter("CAddr2", (object) Caddr2),
        new OleDbParameter(nameof (CAddr3), (object) CAddr3),
        new OleDbParameter("CCity", (object) City),
        new OleDbParameter("CPinCode", (object) Pincode),
        new OleDbParameter("CIntroducer", (object) Introducer),
        new OleDbParameter("CAadharNumber", (object) AdharNumber),
        new OleDbParameter("COtherProof", (object) OtherProof),
        new OleDbParameter("CRationCard", (object) RationCard),
        new OleDbParameter("CInterestRate", (object) InterestRate),
        new OleDbParameter("CEmail", (object) Email),
        new OleDbParameter("CNotes", (object) Notes),
        new OleDbParameter(nameof (CreatedBy), (object) CreatedBy),
        new OleDbParameter(nameof (CreatedOn), (object) CreatedOn),
        new OleDbParameter(nameof (FingerNumber), (object) FingerNumber),
        new OleDbParameter(nameof (SampleNumber), (object) SampleNumber),
        new OleDbParameter("FingerPrint", (object) base64String)
      }, ref strError);
    }

    public static string UpdateCustomerWithFingerPrint(
      string customerCode,
      string CustomerName,
      string Dob,
      string Sex,
      string CPhone,
      string AlternateNumber,
      string Notes,
      string EmaildId,
      string Occupation,
      string Fathername,
      string MotherName,
      string SpouseName,
      string IntroducedBy,
      string MaritalStatus,
      string Education,
      string Religion,
      string InterestRate,
      string CNo,
      string CAddr1,
      string Caddr2,
      string CAddr3,
      string City,
      string Pincode,
      string Landmark,
      string HouseType,
      string OwnerShip,
      string pCNo,
      string pCAddr1,
      string pCaddr2,
      string pCAddr3,
      string pCity,
      string pPincode,
      string pLandmark,
      string pHouseType,
      string pOwnerShip,
      string AadharNumber,
      string PanCard,
      string VoterId,
      string DrivingLicense,
      string RationCard,
      string Others,
      string CreatedBy,
      string CreatedOn,
      byte[] minData,
      int FingerNumber,
      int SampleNumber)
    {
      string strError = "";
      string base64String = Convert.ToBase64String(minData);
      string my_querry = "update tblCustomers set CName=@parameter, Dob=@parameter, Sex=@parameter, CPhone=@parameter, CCell=@parameter, cNotes=@parameter, cEmail=@parameter,Occupation=@parameter,  Fathername =@parameter,  MotherName=@parameter,  SpouseName=@parameter,  cintroducer=@parameter,  MaritalStatus=@parameter, Education=@parameter, Religion=@parameter,             cInterestRate=@parameter,  CNo=@parameter,  CAddr1=@parameter,  Caddr2=@parameter,  CAddr3=@parameter,  cCity=@parameter,  cPincode=@parameter, Landmark=@parameter, HouseType =@parameter, OwnerShip=@parameter,              pNo=@parameter,  pAddr1=@parameter,  paddr2=@parameter,  pAddr3=@parameter,  pCity=@parameter,  pPincode=@parameter,  pLandmark=@parameter,  pHouseType=@parameter,  pOwnerShip=@parameter,              CAadharNumber=@parameter, PanCard=@parameter, VoterId=@parameter, DrivingLicense=@parameter, cRationCard=@parameter, COtherProof=@parameter, CreatedBy=@parameter,  CreatedOn = @parameter, FingerNumber = @parameter,SampleNumber = @SampleNumber,@FingerPrint = @parameter where CID=@CID";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("CName", (object) CustomerName));
      if (Dob == "")
        parameters.Add(new OleDbParameter(nameof (Dob), (object) DBNull.Value));
      else
        parameters.Add(new OleDbParameter(nameof (Dob), (object) Dob));
      parameters.Add(new OleDbParameter(nameof (Sex), (object) Sex));
      parameters.Add(new OleDbParameter(nameof (CPhone), (object) CPhone));
      parameters.Add(new OleDbParameter("CCell", (object) AlternateNumber));
      parameters.Add(new OleDbParameter("CNotes", (object) Notes));
      parameters.Add(new OleDbParameter("CEmail", (object) EmaildId));
      parameters.Add(new OleDbParameter(nameof (Occupation), (object) Occupation));
      parameters.Add(new OleDbParameter("FatherName", (object) Fathername));
      parameters.Add(new OleDbParameter(nameof (MotherName), (object) MotherName));
      parameters.Add(new OleDbParameter("Spousename", (object) SpouseName));
      parameters.Add(new OleDbParameter(nameof (IntroducedBy), (object) IntroducedBy));
      parameters.Add(new OleDbParameter(nameof (MaritalStatus), (object) MaritalStatus));
      parameters.Add(new OleDbParameter(nameof (Education), (object) Education));
      parameters.Add(new OleDbParameter(nameof (Religion), (object) Religion));
      parameters.Add(new OleDbParameter(nameof (InterestRate), (object) InterestRate));
      parameters.Add(new OleDbParameter(nameof (CNo), (object) CNo));
      parameters.Add(new OleDbParameter(nameof (CAddr1), (object) CAddr1));
      parameters.Add(new OleDbParameter("CAddr2", (object) Caddr2));
      parameters.Add(new OleDbParameter(nameof (CAddr3), (object) CAddr3));
      parameters.Add(new OleDbParameter("CCity", (object) City));
      parameters.Add(new OleDbParameter("CPinCode", (object) Pincode));
      parameters.Add(new OleDbParameter("LandMark", (object) Landmark));
      parameters.Add(new OleDbParameter(nameof (HouseType), (object) HouseType));
      parameters.Add(new OleDbParameter(nameof (OwnerShip), (object) OwnerShip));
      parameters.Add(new OleDbParameter(nameof (pCNo), (object) pCNo));
      parameters.Add(new OleDbParameter(nameof (pCAddr1), (object) pCAddr1));
      parameters.Add(new OleDbParameter("pCAddr2", (object) pCaddr2));
      parameters.Add(new OleDbParameter(nameof (pCAddr3), (object) pCAddr3));
      parameters.Add(new OleDbParameter("pCCity", (object) pCity));
      parameters.Add(new OleDbParameter("pCPinCode", (object) pPincode));
      parameters.Add(new OleDbParameter("pLandMark", (object) pLandmark));
      parameters.Add(new OleDbParameter(nameof (pHouseType), (object) pHouseType));
      parameters.Add(new OleDbParameter(nameof (pOwnerShip), (object) pOwnerShip));
      parameters.Add(new OleDbParameter("CAadharNumber", (object) AadharNumber));
      parameters.Add(new OleDbParameter(nameof (PanCard), (object) PanCard));
      parameters.Add(new OleDbParameter(nameof (VoterId), (object) VoterId));
      parameters.Add(new OleDbParameter(nameof (DrivingLicense), (object) DrivingLicense));
      parameters.Add(new OleDbParameter("CRationCard", (object) RationCard));
      parameters.Add(new OleDbParameter("COtherProof", (object) Others));
      parameters.Add(new OleDbParameter(nameof (CreatedBy), (object) CreatedBy));
      parameters.Add(new OleDbParameter(nameof (CreatedOn), (object) CreatedOn));
      parameters.Add(new OleDbParameter(nameof (FingerNumber), (object) FingerNumber));
      parameters.Add(new OleDbParameter(nameof (SampleNumber), (object) SampleNumber));
      parameters.Add(new OleDbParameter("FingerPrint", (object) base64String));
      parameters.Add(new OleDbParameter("CID", (object) customerCode));
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero(my_querry, parameters, ref strError);
    }

    public static string UpdateCustomer(
      string customerCode,
      string CustomerName,
      string Dob,
      string Sex,
      string CPhone,
      string AlternateNumber,
      string Notes,
      string EmaildId,
      string Occupation,
      string Fathername,
      string MotherName,
      string SpouseName,
      string IntroducedBy,
      string MaritalStatus,
      string Education,
      string Religion,
      string InterestRate,
      string CNo,
      string CAddr1,
      string Caddr2,
      string CAddr3,
      string City,
      string Pincode,
      string Landmark,
      string HouseType,
      string OwnerShip,
      string pCNo,
      string pCAddr1,
      string pCaddr2,
      string pCAddr3,
      string pCity,
      string pPincode,
      string pLandmark,
      string pHouseType,
      string pOwnerShip,
      string AadharNumber,
      string PanCard,
      string VoterId,
      string DrivingLicense,
      string RationCard,
      string Others,
      string CreatedBy,
      string CreatedOn)
    {
      string strError = "";
      string my_querry = "update tblCustomers set CName=@CName, Dob=@Dob, Sex=@Sex, CPhone=@CPhone, CCell=@CCell, CNotes=@CNotes, cEmail=@cEmail,Occupation=@Occupation,  Fathername =@FatherName,  MotherName=@MotherName,  SpouseName=@SpouseName,  cintroducer=@cintroducer,  MaritalStatus=@MaritalStatus, Education=@Education, Religion=@Religion,             cInterestRate=@cInterestRate,  CNo=@CNo,  CAddr1=@CAddr1,  Caddr2=@Caddr2,  CAddr3=@Caddr3,  cCity=@cCity,  cPincode=@cPincode, Landmark=@Landmark, HouseType =@HouseType, OwnerShip=@OwnerShip,              pNo=@pNo,  pAddr1=@pAddr1,  paddr2=@paddr2,  pAddr3=@pAddr3,  pCity=@pCity,  pPincode=@pPincode,  pLandmark=@pLandmark,  pHouseType=@pHouseType,  pOwnerShip=@pOwnerShip,              CAadharNumber=@pAadharNumber, PanCard=@PanCard, VoterId=@VoterId, DrivingLicense=@DrivingLicense, cRationCard=@cRationCard, COtherProof=@COtherProof, CreatedBy=@CreatedBy,  CreatedOn = @CreatedOn where CID=@CID";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("CName", (object) CustomerName));
      if (Dob == "")
        parameters.Add(new OleDbParameter(nameof (Dob), (object) DBNull.Value));
      else
        parameters.Add(new OleDbParameter(nameof (Dob), (object) Dob));
      parameters.Add(new OleDbParameter(nameof (Sex), (object) Sex));
      parameters.Add(new OleDbParameter(nameof (CPhone), (object) CPhone));
      parameters.Add(new OleDbParameter("CCell", (object) AlternateNumber));
      parameters.Add(new OleDbParameter("CNotes", (object) Notes));
      parameters.Add(new OleDbParameter("CEmail", (object) EmaildId));
      parameters.Add(new OleDbParameter(nameof (Occupation), (object) Occupation));
      parameters.Add(new OleDbParameter("FatherName", (object) Fathername));
      parameters.Add(new OleDbParameter(nameof (MotherName), (object) MotherName));
      parameters.Add(new OleDbParameter("Spousename", (object) SpouseName));
      parameters.Add(new OleDbParameter(nameof (IntroducedBy), (object) IntroducedBy));
      parameters.Add(new OleDbParameter(nameof (MaritalStatus), (object) MaritalStatus));
      parameters.Add(new OleDbParameter(nameof (Education), (object) Education));
      parameters.Add(new OleDbParameter(nameof (Religion), (object) Religion));
      parameters.Add(new OleDbParameter(nameof (InterestRate), (object) InterestRate));
      parameters.Add(new OleDbParameter(nameof (CNo), (object) CNo));
      parameters.Add(new OleDbParameter(nameof (CAddr1), (object) CAddr1));
      parameters.Add(new OleDbParameter("CAddr2", (object) Caddr2));
      parameters.Add(new OleDbParameter(nameof (CAddr3), (object) CAddr3));
      parameters.Add(new OleDbParameter("CCity", (object) City));
      parameters.Add(new OleDbParameter("CPinCode", (object) Pincode));
      parameters.Add(new OleDbParameter("LandMark", (object) Landmark));
      parameters.Add(new OleDbParameter(nameof (HouseType), (object) HouseType));
      parameters.Add(new OleDbParameter(nameof (OwnerShip), (object) OwnerShip));
      parameters.Add(new OleDbParameter(nameof (pCNo), (object) pCNo));
      parameters.Add(new OleDbParameter(nameof (pCAddr1), (object) pCAddr1));
      parameters.Add(new OleDbParameter("pCAddr2", (object) pCaddr2));
      parameters.Add(new OleDbParameter(nameof (pCAddr3), (object) pCAddr3));
      parameters.Add(new OleDbParameter("pCCity", (object) pCity));
      parameters.Add(new OleDbParameter("pCPinCode", (object) pPincode));
      parameters.Add(new OleDbParameter("pLandMark", (object) pLandmark));
      parameters.Add(new OleDbParameter(nameof (pHouseType), (object) pHouseType));
      parameters.Add(new OleDbParameter(nameof (pOwnerShip), (object) pOwnerShip));
      parameters.Add(new OleDbParameter("CAadharNumber", (object) AadharNumber));
      parameters.Add(new OleDbParameter(nameof (PanCard), (object) PanCard));
      parameters.Add(new OleDbParameter(nameof (VoterId), (object) VoterId));
      parameters.Add(new OleDbParameter(nameof (DrivingLicense), (object) DrivingLicense));
      parameters.Add(new OleDbParameter("CRationCard", (object) RationCard));
      parameters.Add(new OleDbParameter("COtherProof", (object) Others));
      parameters.Add(new OleDbParameter(nameof (CreatedBy), (object) CreatedBy));
      parameters.Add(new OleDbParameter(nameof (CreatedOn), (object) CreatedOn));
      parameters.Add(new OleDbParameter("CID", (object) customerCode));
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero(my_querry, parameters, ref strError);
    }

    public static DataTable getChildren(string customerCode, string sex, string spouseCode)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry;
      if (sex == "MALE")
      {
        if (spouseCode == "")
        {
          my_querry = "select * from tblcustomers where fathername = @customerCode";
          parameters.Add(new OleDbParameter(nameof (customerCode), (object) customerCode));
        }
        else
        {
          my_querry = "(select * from tblcustomers where fathername = @customerCode) union all ( select * from tblcustomers where mothername = @spouseCode and (fathername  = '' OR fathername IS NULL))";
          parameters.Add(new OleDbParameter(nameof (customerCode), (object) customerCode));
          parameters.Add(new OleDbParameter("motherCode", (object) spouseCode));
        }
      }
      else if (spouseCode == "")
      {
        my_querry = "select * from tblcustomers where mothername = @customerCode";
        parameters.Add(new OleDbParameter(nameof (customerCode), (object) customerCode));
      }
      else
      {
        my_querry = "(select * from tblcustomers where mothername = @customerCode) union all ( select * from tblcustomers where fathername = @spouseCode and (mothername  = '' OR mothername IS NULL))";
        parameters.Add(new OleDbParameter(nameof (customerCode), (object) customerCode));
        parameters.Add(new OleDbParameter("motherCode", (object) spouseCode));
      }
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getChildrenNew(string customerCode, string sex)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry;
      if (sex == "MALE")
      {
        my_querry = "select * from tblcustomers where fathername = @customerCode";
        parameters.Add(new OleDbParameter(nameof (customerCode), (object) customerCode));
      }
      else
      {
        my_querry = "select * from tblcustomers where mothername = @customerCode";
        parameters.Add(new OleDbParameter(nameof (customerCode), (object) customerCode));
      }
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getBrothersAndSisters(
      string customerCode,
      string sex,
      string spouseCode)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry;
      if (spouseCode == "")
      {
        my_querry = "select * from tblcustomers where fathername = @customerCode";
        parameters.Add(new OleDbParameter(nameof (customerCode), (object) customerCode));
      }
      else
      {
        my_querry = "(select * from tblcustomers where fathername = @customerCode) union all ( select * from tblcustomers where mothername = @spouseCode and (fathername  = '' OR fathername IS NULL))";
        parameters.Add(new OleDbParameter(nameof (customerCode), (object) customerCode));
        parameters.Add(new OleDbParameter("motherCode", (object) spouseCode));
      }
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static string getTheCustomerIdBelongingToThis(string PhoneNumber)
    {
      string strError = "";
      string my_querry = "select * from tblcustomers where CPhone = @CPhone or CCell = @CCell";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("CPhone", (object) PhoneNumber));
      parameters.Add(new OleDbParameter("CCell", (object) PhoneNumber));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["CID"].ToString() : "";
    }

    public static DataTable getDataTableWhereAddr1Is(string strAddr1)
    {
      string strError = "";
      string my_querry = "select * from tblcustomers where caddr1 = @addr1 order by createdon desc";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("addr1", (object) strAddr1));
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }
  }
}
