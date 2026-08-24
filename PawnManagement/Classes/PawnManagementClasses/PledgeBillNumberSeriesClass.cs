
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class PledgeBillNumberSeriesClass
  {
    public static void addShopCodeInBillNumberSEriesTable(string strShopCode)
    {
      switch (FormMain.BillNumberSeries)
      {
        case "SINGLE":
          try
          {
            string strError = "";
            if (!(SQLHelper.RunCommand("insert into tblPledgeBillNumberSeries(shopCode,CurrentSeries,RedemptionCurrentSeries,Active) values(@shopCode,'A','A','1')", new List<OleDbParameter>()
            {
              new OleDbParameter("shopCode", (object) strShopCode)
            }, ref strError) != "Done"))
              break;
            PawnManagementClass.InsertIntoException("form shopdetails.addshopcodeinbillnumberseriestable()", strError, FormMain.username, DateTime.Now.ToString());
            int num = (int) MessageBox.Show("Error in Adding" + strError);
            break;
          }
          catch (Exception ex)
          {
            PawnManagementClass.InsertIntoException("form shopdetails.addshopcodeinbillnumberseriestable()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
            throw;
          }
        case "DOUBLE":
          try
          {
            string strError = "";
            if (SQLHelper.RunCommand("insert into tblPledgeBillNumberSeries(shopCode,CurrentSeries,RedemptionCurrentSeries,Active) values(@shopCode,'AA','AB','1')", new List<OleDbParameter>()
            {
              new OleDbParameter("shopCode", (object) strShopCode)
            }, ref strError) != "Done")
            {
              PawnManagementClass.InsertIntoException("form shopdetails.addshopcodeinbillnumberseriestable()", strError, FormMain.username, DateTime.Now.ToString());
              int num = (int) MessageBox.Show("Error in Adding" + strError);
            }
          }
          catch (Exception ex)
          {
            PawnManagementClass.InsertIntoException("form shopdetails.addshopcodeinbillnumberseriestable()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
            throw;
          }
          break;
      }
    }
  }
}
