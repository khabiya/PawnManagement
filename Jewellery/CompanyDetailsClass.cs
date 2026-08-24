using PawnManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace Jewellery
{
  internal class CompanyDetailsClass
  {
    public static DataTable getCompanyCodes()
    {
      string strError = "";
      string my_querry = "select CompanyCode,CompanyName from tblCompanyDetails";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static List<string> getCompanyNames()
    {
      string strError = "";
      List<string> companyNames = new List<string>();
      string my_querry = "select CompanyCode from tblCompanyDetails";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          companyNames.Add(row["CompanyCode"].ToString());
      }
      return companyNames;
    }

    public static string deleteCompany(string compnayCode)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblCompanyDetails where companyCode  =@CompanyCode", new List<OleDbParameter>()
      {
        new OleDbParameter("CompanyCode", (object) compnayCode)
      }, ref strError);
    }

    public static bool checkIfCompanyAlreadyExists(string companyCode)
    {
      string strError = "";
      string my_querry = "select * from tblCompanyDetails where CompanyCode = @CompanyCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("CompanyCode", (object) companyCode)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string getDefaultCompanyCode()
    {
      string strError = "";
      string my_querry = "select * from tblCompanyDetails where DefaultCompany = @Defaultcompany";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("DefaultCompany", (object) "Y")
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0]["CompanyCode"].ToString();
      return "";
    }

    public static DataTable getCompanyDetails(string companyCode)
    {
      string strError = "";
      string my_querry = "select * from tblCompanyDetails where CompanyCode = @CompanyCode";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("CompanyCode", (object) companyCode)
      }, ref strError);
    }

    public static string addCompanyDetails(
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
      string Gst,
      string NumberOfDecimalPlaces,
      string editedBy,
      DateTime editedOn,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("insert into tblCompanyDetails( CompanyCode, CompanyName, MailingName, DoorNumber, Address1, Address2, Location, City, Pincode, State, Country, PhoneNumber, AlternateNumber, FaxNumber, Email, Website, GstNumber, NumberOfDecimalPlaces,EditedBy,EditedOn,  createdBy, createdOn) values ( @CompanyCode, @CompanyName, @MailingName, @DoorNumber, @Address1, @Address2, @Location, @City, @Pincode, @State, @Country, @PhoneNumber, @AlternateNumber, @FaxNumber, @Email, @Website, @GstNumber, @NumberOfDecimalPlaces,@EditedBy,@EditedOn,  @createdBy, @createdOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (CompanyCode), (object) CompanyCode),
        new OleDbParameter(nameof (CompanyName), (object) CompanyName),
        new OleDbParameter(nameof (MailingName), (object) MailingName),
        new OleDbParameter(nameof (DoorNumber), (object) DoorNumber),
        new OleDbParameter(nameof (Address1), (object) Address1),
        new OleDbParameter(nameof (Address2), (object) Address2),
        new OleDbParameter(nameof (Location), (object) Location),
        new OleDbParameter(nameof (City), (object) City),
        new OleDbParameter(nameof (Pincode), (object) Pincode),
        new OleDbParameter(nameof (State), (object) State),
        new OleDbParameter(nameof (Country), (object) Country),
        new OleDbParameter(nameof (PhoneNumber), (object) PhoneNumber),
        new OleDbParameter(nameof (AlternateNumber), (object) AlternateNumber),
        new OleDbParameter(nameof (FaxNumber), (object) FaxNumber),
        new OleDbParameter(nameof (Email), (object) Email),
        new OleDbParameter("WebSite", (object) Website),
        new OleDbParameter("GstNumber", (object) Gst),
        new OleDbParameter(nameof (NumberOfDecimalPlaces), (object) NumberOfDecimalPlaces),
        new OleDbParameter("EditedBy", (object) editedBy),
        new OleDbParameter("EditedOn", (object) editedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedBy", (object) createdBy),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString("dd/MM/yyyy"))
      }, ref strError);
    }

    public static string editCompanyDetails(
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
      string GstNumber,
      string NumberOfDecimalPlaces,
      string editedBy,
      DateTime editedOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("Update tblCompanyDetails set  CompanyName = @CompanyName,MailingName =  @MailingName,DoorNumber =  @DoorNumber,Address1 = @Address1,Address2 = @Address2,Location = @Location,City =  @City,Pincode = @Pincode,State =  @State,Country =  @Country,PhoneNumber =  @PhoneNumber,AlternateNumber =  @AlternateNumber,FaxNumber =  @FaxNumber,Email =  @Email,Website =  @Website,GstNumber =  @GstNumber,NumberOfDecimalPlaces =  @NumberOfDecimalPlaces,EditedBy = @EditedBy,EditedOn = @EditedOn  where CompanyCode =  @CompanyCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (CompanyName), (object) CompanyName),
        new OleDbParameter(nameof (MailingName), (object) MailingName),
        new OleDbParameter(nameof (DoorNumber), (object) DoorNumber),
        new OleDbParameter(nameof (Address1), (object) Address1),
        new OleDbParameter(nameof (Address2), (object) Address2),
        new OleDbParameter(nameof (Location), (object) Location),
        new OleDbParameter(nameof (City), (object) City),
        new OleDbParameter(nameof (Pincode), (object) Pincode),
        new OleDbParameter(nameof (State), (object) State),
        new OleDbParameter(nameof (Country), (object) Country),
        new OleDbParameter(nameof (PhoneNumber), (object) PhoneNumber),
        new OleDbParameter(nameof (AlternateNumber), (object) AlternateNumber),
        new OleDbParameter(nameof (FaxNumber), (object) FaxNumber),
        new OleDbParameter(nameof (Email), (object) Email),
        new OleDbParameter("WebSite", (object) Website),
        new OleDbParameter(nameof (GstNumber), (object) GstNumber),
        new OleDbParameter(nameof (NumberOfDecimalPlaces), (object) NumberOfDecimalPlaces),
        new OleDbParameter("EditedBy", (object) editedBy),
        new OleDbParameter("EditedOn", (object) editedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (CompanyCode), (object) CompanyCode)
      }, ref strError);
    }

    public static string setDefaultCompany(string CompanyCode)
    {
      string strError1 = "";
      SQLHelper.RunCommand("Update tblCompanyDetails set  DefaultCompany  = @DefaultCompany where CompanyCode =  @CompanyCode", new List<OleDbParameter>()
      {
        new OleDbParameter("DefaultCompany", (object) "Y"),
        new OleDbParameter(nameof (CompanyCode), (object) CompanyCode)
      }, ref strError1);
      string strError2 = "";
      return SQLHelper.RunCommand("Update tblCompanyDetails set DefaultCompany = 'N' where CompanyCode <> @CompanyCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (CompanyCode), (object) CompanyCode)
      }, ref strError2);
    }
  }
}
