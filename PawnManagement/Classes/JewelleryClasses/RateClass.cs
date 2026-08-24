
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.JewelleryClasses
{
  internal class RateClass
  {
    public static DataTable getCompleteRateTable()
    {
      string strError = "";
      string my_querry = "select ID,MetalType,PureRate,KachaRate,BoardRate,RateDate from tblRate order by CreatedOn";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getAllTheDatesInADay(string Date)
    {
      string strError = "";
      string my_querry = "select * from tblRate where RateDate = @RateDate";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("RateDate", (object) Date)
      }, ref strError);
    }

    public static DataTable getRatesForThisID(string ID)
    {
      string strError = "";
      string my_querry = "select * from tblRate where ID = @ID";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ID), (object) ID)
      }, ref strError);
    }

    public static string deleteRate(string ID)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblRate where ID = @ID", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ID), (object) ID)
      }, ref strError);
    }

    public static string getTodaysRate(string strMetalType, DateTime dtDate)
    {
      string strError = "";
      string my_querry = "select * from tblRate where MetalType = @MetalType and RateDate = @RateDate order By EditedOn Desc";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("MetalType", (object) strMetalType),
        new OleDbParameter("RateDate", (object) dtDate.ToString("dd/MM/yyyy"))
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["BoardrATE"] != null)
        return dataTable2.Rows[0]["BoardRate"].ToString();
      return "";
    }

    public static string addRate(
      string MetalType,
      double PureRate,
      double KachaRate,
      double BoardRate,
      DateTime RateDate,
      DateTime RateTime,
      string EditedBy,
      DateTime EditedOn,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblRate(MetalType,PureRate,KachaRate,BoardRate,RateDate,RateTime,EditedBy,EditedOn,CreatedBy,CreatedOn) values (@MetalType,@PureRate,@KachaRate,@BoardRate,@RateDate,@RateTime,@EditedBy,@EditedOn,@CreatedBy,@CreatedOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (MetalType), (object) MetalType),
        new OleDbParameter(nameof (PureRate), (object) PureRate),
        new OleDbParameter(nameof (KachaRate), (object) KachaRate),
        new OleDbParameter(nameof (BoardRate), (object) BoardRate),
        new OleDbParameter(nameof (RateDate), (object) RateDate.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (RateTime), (object) RateTime.ToString()),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString()),
        new OleDbParameter("CreatedBy", (object) createdBy),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString())
      }, ref strError);
    }

    public static string editRate(
      string ID,
      string MetalType,
      double PureRate,
      double KachaRate,
      double BoardRate,
      DateTime RateDate,
      DateTime RateTime,
      string editedBy,
      DateTime editedOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblRAte set MetalType =  @MetalType,PureRate = @PureRate, KachaRate = @KachaRate,BoardRate = @BoardRate,RateDate = @RateDate,RateTime = @RateTime,EditedBy = @EditedBy,EditedOn = @EditedOn where ID  = @ID", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (MetalType), (object) MetalType),
        new OleDbParameter(nameof (PureRate), (object) PureRate),
        new OleDbParameter(nameof (KachaRate), (object) KachaRate),
        new OleDbParameter(nameof (BoardRate), (object) BoardRate),
        new OleDbParameter(nameof (RateDate), (object) RateDate.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (RateTime), (object) RateTime),
        new OleDbParameter("EditedBy", (object) editedBy),
        new OleDbParameter("EditedOn", (object) editedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (ID), (object) ID)
      }, ref strError);
    }
  }
}
