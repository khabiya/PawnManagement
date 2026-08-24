

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PawnManagement
{
  internal class ShopDetailsClass
  {
    public static double getInterestRate(string ShopCode)
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select * from tblShopDetails where Active = '1' and shopcode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("pawn management class.getShopCodes", strError, FormMain.username, DateTime.Now.ToString());
        return 16.0;
      }
      return dataTable != null && dataTable.Rows.Count > 0 && dataTable.Rows[0]["RateOfInterest"] != null && dataTable.Rows[0]["RateOfInterest"].ToString().Trim() != "" ? double.Parse(dataTable.Rows[0]["RateOfInterest"].ToString()) : 16.0;
    }

    public static DataTable getCompleteShopDetails()
    {
      string strError = "";
      return SQLHelper.GetDataTable("select * from tblShopDetails where Active = '1'", new List<OleDbParameter>(), ref strError);
    }

    public static DataTable getTheseColumnsFromShopDetails(
      string ShopCode,
      string ShopName,
      string Proprietor)
    {
      string strError = "";
      return SQLHelper.GetDataTable("select " + ShopCode + "," + ShopName + "," + Proprietor + " from tblShopDetails where Active = '1'", new List<OleDbParameter>(), ref strError);
    }

    public static void deleteShopCode(string ShopCode)
    {
      string strError1 = "";
      if (SQLHelper.RunCommand("update tblshopdetails set Active=@Active where shopcode =@shopCode", new List<OleDbParameter>()
      {
        new OleDbParameter("Active", (object) "0"),
        new OleDbParameter("shopCode", (object) ShopCode)
      }, ref strError1) != "Done")
      {
        PawnManagementClass.InsertIntoException("form License master.deletetoolstripmenuitem_click", strError1, FormMain.username, DateTime.Now.ToString());
      }
      else
      {
        string strError2 = "";
        if (SQLHelper.RunCommand("update tblPledgeBillNumberSeries set Active=@Active where shopcode =@shopCode", new List<OleDbParameter>()
        {
          new OleDbParameter("Active", (object) "0"),
          new OleDbParameter("shopCode", (object) ShopCode)
        }, ref strError2) != "Done")
          PawnManagementClass.InsertIntoException("form License master.deletetoolstripmenuitem_click", strError1, FormMain.username, DateTime.Now.ToString());
      }
    }

    public static bool checkDuplicateShopName(string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblshopdetails where ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Shop Details.checkduplicateshopname", strError, FormMain.username, DateTime.Now.ToString());
        return false;
      }
      return dataTable2 == null || dataTable2.Rows.Count <= 0;
    }

    public static string addShopDetails(
      string ShopCode,
      string ShopName,
      string ShopNameTamil,
      string Proprietor,
      string Address1,
      string Address2,
      string Location,
      string city,
      string Pincode,
      string PblNumber,
      string PhoneNumber1,
      string PhoneNumber2,
      string RateOfInterest,
      string CreatedBy,
      DateTime CreatedOn,
      string LedgerCode,
      string VoucherCode,
      string LedgerCodeInterest,
      string VoucherCodeInterestGrirvi,
      string VoucherCodeInterestChoot)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblShopDetails(ShopCode,ShopName,ShopNameTamil,proprietor,address1,address2,location,city,pincode,pblnumber,phonenumber1,phonenumber2,rateofinterest,createdBy,CreatedOn,Active,LedgerCode,VoucherCode,LedgerCodeInterest,VoucherCodeInterestGirvi,VoucherCodeInterestChoot,Hidden) values(@ShopCode,@ShopName,@ShopNameTamil,@Proprietor,@Address1,@Address2,@Location,@City,@Pincode,@Pblnumber,@Phonenumber1,@Phonenumber2,@Rateofinterest,@CreatedBy,@CreatedOn,@Active,@LedgerCode,@VoucherCode,@LedgerCodeInterest,@VoucherCodeInterestGirvi,@VoucherCodeInterestChoot,@Hidden)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShopCode), (object) ShopCode),
        new OleDbParameter(nameof (ShopName), (object) ShopName),
        new OleDbParameter(nameof (ShopNameTamil), (object) ShopNameTamil),
        new OleDbParameter(nameof (Proprietor), (object) Proprietor),
        new OleDbParameter(nameof (Address1), (object) Address1),
        new OleDbParameter(nameof (Address2), (object) Address2),
        new OleDbParameter(nameof (Location), (object) Location),
        new OleDbParameter("City", (object) city),
        new OleDbParameter(nameof (Pincode), (object) Pincode),
        new OleDbParameter(nameof (PblNumber), (object) PblNumber),
        new OleDbParameter(nameof (PhoneNumber1), (object) PhoneNumber1),
        new OleDbParameter(nameof (PhoneNumber2), (object) PhoneNumber2),
        new OleDbParameter(nameof (RateOfInterest), (object) RateOfInterest),
        new OleDbParameter(nameof (CreatedBy), (object) CreatedBy),
        new OleDbParameter(nameof (CreatedOn), (object) CreatedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter("Active", (object) "1"),
        new OleDbParameter(nameof (LedgerCode), (object) LedgerCode),
        new OleDbParameter("Vouchercode", (object) VoucherCode),
        new OleDbParameter(nameof (LedgerCodeInterest), (object) LedgerCodeInterest),
        new OleDbParameter("VoucherCodeInterestGirvi", (object) VoucherCodeInterestGrirvi),
        new OleDbParameter(nameof (VoucherCodeInterestChoot), (object) VoucherCodeInterestChoot),
        new OleDbParameter("Hidden", (object) "N")
      }, ref strError);
    }

    public static string editShopDetails(
      string ShopCode,
      string ShopName,
      string ShopNameTamil,
      string Proprietor,
      string Address1,
      string Address2,
      string Location,
      string city,
      string Pincode,
      string PblNumber,
      string PhoneNumber1,
      string PhoneNumber2,
      string RateOfInterest)
    {
      string strError = "";
      return SQLHelper.RunCommand("Update tblShopDetails set ShopName = @ShopName,ShopNametamil = @ShopNameTamil,Proprietor = @Proprietor,Address1= @Address1,Address2= @Address2,Location= @Location,City=@City,Pincode=@Pincode,PblNumber=@PblNumber,PhoneNumber1=@PhoneNumber1,PhoneNumber2=@PhoneNumber2,RateOfInterest=@RateOfInterest where shopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShopName), (object) ShopName),
        new OleDbParameter(nameof (ShopNameTamil), (object) ShopNameTamil),
        new OleDbParameter(nameof (Proprietor), (object) Proprietor),
        new OleDbParameter(nameof (Address1), (object) Address1),
        new OleDbParameter(nameof (Address2), (object) Address2),
        new OleDbParameter(nameof (Location), (object) Location),
        new OleDbParameter("City", (object) city),
        new OleDbParameter(nameof (Pincode), (object) Pincode),
        new OleDbParameter(nameof (PblNumber), (object) PblNumber),
        new OleDbParameter(nameof (PhoneNumber1), (object) PhoneNumber1),
        new OleDbParameter(nameof (PhoneNumber2), (object) PhoneNumber2),
        new OleDbParameter(nameof (RateOfInterest), (object) RateOfInterest),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
    }

    public static void setAsDefaul(string ShopCode)
    {
      string strError1 = "";
      if (!(SQLHelper.RunCommand("Update tblShopDetails set DefaultShop='Y' where shopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError1) == "Done"))
      {
        int num1 = (int) MessageBox.Show("Error in updating" + strError1);
      }
      string strError2 = "";
      if (SQLHelper.RunCommand("Update tblShopDetails set DefaultShop='N' where shopCode <> @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError2) == "Done")
        return;
      int num2 = (int) MessageBox.Show("Error in updating" + strError2);
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(string ColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblShopDetails where " + ColumnName + "= @" + ColumnName;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName, (object) strValue)
      }, ref strError);
    }

    public static string getOldestCreatedLicenseDate()
    {
      string strError = "";
      string my_querry = "Select min(createdOn) AS CreatedOn from  tblshopdetails ";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && ((dataTable2.Rows[0]["CreatedOn"] == null ? 1 : 0) | (dataTable2.Rows[0]["CreatedOn"] == null ? 0 : (dataTable2.Rows[0]["CreatedOn"].ToString() == "" ? 1 : 0))) == 0 ? DateTime.Parse(dataTable2.Rows[0]["CreatedOn"].ToString()).ToString("dd/MM/yyyy") : "";
    }
  }
}
