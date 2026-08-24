
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Xml;

namespace PawnManagement
{
  internal class SQLHelper
  {
    public static string _strDBConnectionString;
    public static string _strDBConnectionStringForUpdate = "Provider=Microsoft.ACE.OLEDB.12.0;Data source = Update\\\\PawnManagement.accdb;Jet OLEDB:Database Password = (&()&$#)!&";

    public static void updateConfigFile(string con)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
      foreach (XmlElement xmlElement in (XmlNode) xmlDocument.DocumentElement)
      {
        if (xmlElement.Name == "connectionStrings")
          xmlElement.FirstChild.Attributes[2].Value = con;
      }
      xmlDocument.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
    }

    public static DataTable GetDataTable(string my_querry)
    {
      OleDbConnection connection = new OleDbConnection(SQLHelper._strDBConnectionString);
      try
      {
        connection.Open();
        OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(new OleDbCommand(my_querry, connection));
        DataTable dataTable = new DataTable();
        oleDbDataAdapter.Fill(dataTable);
        return dataTable;
      }
      catch (Exception ex)
      {
        return (DataTable) null;
      }
      finally
      {
        connection.Close();
      }
    }

    public static DataTable GetDataTable(
      string my_querry,
      List<OleDbParameter> parameters,
      ref string strError)
    {
      OleDbConnection connection = new OleDbConnection(SQLHelper._strDBConnectionString);
      try
      {
        connection.Open();
        OleDbCommand selectCommand = new OleDbCommand(my_querry, connection);
        if (parameters != null)
        {
          foreach (OleDbParameter parameter in parameters)
            selectCommand.Parameters.Add(parameter);
        }
        OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        oleDbDataAdapter.Fill(dataTable);
        return dataTable;
      }
      catch (Exception ex)
      {
        strError = "Error - " + ex.Message + "\n" + ex.StackTrace;
        return (DataTable) null;
      }
      finally
      {
        connection.Close();
      }
    }

    public static DataTable GetDataTable(
      string my_querry,
      List<OleDbParameter> parameters,
      ref string strError,
      string source)
    {
      OleDbConnection connection = new OleDbConnection(SQLHelper._strDBConnectionString);
      try
      {
        connection.Open();
        OleDbCommand selectCommand = new OleDbCommand(my_querry, connection);
        if (parameters != null)
        {
          foreach (OleDbParameter parameter in parameters)
            selectCommand.Parameters.Add(parameter);
        }
        OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        oleDbDataAdapter.Fill(dataTable);
        return dataTable;
      }
      catch (Exception ex)
      {
        strError = "Error - " + ex.Message + "\n" + ex.StackTrace;
        PawnManagementClass.InsertIntoException(source, ex.Message, ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        return (DataTable) null;
      }
      finally
      {
        connection.Close();
      }
    }

    public static DataTable GetDataTable(string my_querry, ref string strError)
    {
      OleDbConnection connection = new OleDbConnection(SQLHelper._strDBConnectionString);
      try
      {
        connection.Open();
        OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(new OleDbCommand(my_querry, connection));
        DataTable dataTable = new DataTable();
        oleDbDataAdapter.Fill(dataTable);
        return dataTable;
      }
      catch (Exception ex)
      {
        strError = "Error - " + ex.Message + ex.StackTrace;
        return (DataTable) null;
      }
      finally
      {
        connection.Close();
      }
    }

    public static DataTable GetDataTableForUpdate(string my_querry, ref string strError)
    {
      OleDbConnection connection = new OleDbConnection(SQLHelper._strDBConnectionStringForUpdate);
      try
      {
        connection.Open();
        OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(new OleDbCommand(my_querry, connection));
        DataTable dataTable = new DataTable();
        oleDbDataAdapter.Fill(dataTable);
        return dataTable;
      }
      catch (Exception ex)
      {
        strError = "Error - " + ex.Message + ex.StackTrace;
        return (DataTable) null;
      }
      finally
      {
        connection.Close();
      }
    }

    public static DataTable getTableNamesUpdate(ref string strError)
    {
      OleDbConnection oleDbConnection = new OleDbConnection(SQLHelper._strDBConnectionStringForUpdate);
      try
      {
        oleDbConnection.Open();
        return oleDbConnection.GetSchema("Tables");
      }
      catch (Exception ex)
      {
        strError = "Error - " + ex.Message + ex.StackTrace;
        return (DataTable) null;
      }
      finally
      {
        oleDbConnection.Close();
      }
    }

    public static DataTable getTableNames(ref string strError)
    {
      OleDbConnection oleDbConnection = new OleDbConnection(SQLHelper._strDBConnectionString);
      try
      {
        oleDbConnection.Open();
        return oleDbConnection.GetSchema("Tables");
      }
      catch (Exception ex)
      {
        strError = "Error - " + ex.Message + ex.StackTrace;
        return (DataTable) null;
      }
      finally
      {
        oleDbConnection.Close();
      }
    }

    public static DataTable GetDataTable(string my_querry, ref string strError, string source)
    {
      OleDbConnection connection = new OleDbConnection(SQLHelper._strDBConnectionString);
      try
      {
        connection.Open();
        OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(new OleDbCommand(my_querry, connection));
        DataTable dataTable = new DataTable();
        oleDbDataAdapter.Fill(dataTable);
        return dataTable;
      }
      catch (Exception ex)
      {
        strError = "Error - " + ex.Message + ex.StackTrace;
        PawnManagementClass.InsertIntoException(source, ex.Message, ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        return (DataTable) null;
      }
      finally
      {
        connection.Close();
      }
    }

    public static string RunCommand(
      string my_querry,
      List<OleDbParameter> parameters,
      ref string strError)
    {
      OleDbConnection connection = new OleDbConnection(SQLHelper._strDBConnectionString);
      try
      {
        connection.Open();
        OleDbCommand oleDbCommand = new OleDbCommand(my_querry, connection);
        if (parameters != null)
        {
          foreach (OleDbParameter parameter in parameters)
            oleDbCommand.Parameters.Add(parameter);
        }
        oleDbCommand.ExecuteNonQuery();
        return "Done";
      }
      catch (Exception ex)
      {
        strError = ex.Message + ex.StackTrace;
        return strError;
      }
      finally
      {
        connection.Close();
      }
    }

    public static string RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero(
      string my_querry,
      List<OleDbParameter> parameters,
      ref string strError)
    {
      OleDbConnection connection = new OleDbConnection(SQLHelper._strDBConnectionString);
      try
      {
        connection.Open();
        OleDbCommand oleDbCommand = new OleDbCommand(my_querry, connection);
        if (parameters != null)
        {
          foreach (OleDbParameter parameter in parameters)
            oleDbCommand.Parameters.Add(parameter);
        }
        return oleDbCommand.ExecuteNonQuery() > 0 ? "Done" : "Error";
      }
      catch (Exception ex)
      {
        strError = ex.Message + ex.StackTrace;
        return strError;
      }
      finally
      {
        connection.Close();
      }
    }

    public static string RunCommand(
      string my_querry,
      List<OleDbParameter> parameters,
      ref string strError,
      string source)
    {
      OleDbConnection connection = new OleDbConnection(SQLHelper._strDBConnectionString);
      try
      {
        connection.Open();
        OleDbCommand oleDbCommand = new OleDbCommand(my_querry, connection);
        if (parameters != null)
        {
          foreach (OleDbParameter parameter in parameters)
            oleDbCommand.Parameters.Add(parameter);
        }
        oleDbCommand.ExecuteNonQuery();
        return "Done";
      }
      catch (Exception ex)
      {
        strError = ex.Message + ex.StackTrace;
        PawnManagementClass.InsertIntoException(source, ex.Message, ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        return strError;
      }
      finally
      {
        connection.Close();
      }
    }

    public static string RunCommand(string my_querry, ref string strError)
    {
      OleDbConnection connection = new OleDbConnection(SQLHelper._strDBConnectionString);
      try
      {
        connection.Open();
        new OleDbCommand(my_querry, connection).ExecuteNonQuery();
        return "Done";
      }
      catch (Exception ex)
      {
        strError = "Error - " + ex.Message + "\n" + ex.StackTrace;
        return strError;
      }
      finally
      {
        connection.Close();
      }
    }

    public static string RunCommandAndReturnNumberOfRowsAffected(
      string my_querry,
      ref string strError)
    {
      OleDbConnection connection = new OleDbConnection(SQLHelper._strDBConnectionString);
      try
      {
        connection.Open();
        return new OleDbCommand(my_querry, connection).ExecuteNonQuery().ToString();
      }
      catch (Exception ex)
      {
        strError = "Error - " + ex.Message + "\n" + ex.StackTrace;
        return strError;
      }
      finally
      {
        connection.Close();
      }
    }

    public static string RunCommandUpdate(string my_querry, ref string strError)
    {
      OleDbConnection connection = new OleDbConnection(SQLHelper._strDBConnectionStringForUpdate);
      try
      {
        connection.Open();
        new OleDbCommand(my_querry, connection).ExecuteNonQuery();
        return "Done";
      }
      catch (Exception ex)
      {
        strError = "Error - " + ex.Message + "\n" + ex.StackTrace;
        return strError;
      }
      finally
      {
        connection.Close();
      }
    }

    public static string RunCommand(string my_querry, ref string strError, string source)
    {
      OleDbConnection connection = new OleDbConnection(SQLHelper._strDBConnectionString);
      try
      {
        connection.Open();
        new OleDbCommand(my_querry, connection).ExecuteNonQuery();
        return "Done";
      }
      catch (Exception ex)
      {
        strError = "Error - " + ex.Message + "\n" + ex.StackTrace;
        PawnManagementClass.InsertIntoException(source, ex.Message, ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        return strError;
      }
      finally
      {
        connection.Close();
      }
    }
  }
}
