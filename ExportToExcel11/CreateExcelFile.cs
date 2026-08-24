
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace ExportToExcel11
{
  public class CreateExcelFile
  {
    public static bool CreateExcelDocument<T>(List<T> list, string xlsxFilePath) => CreateExcelFile.CreateExcelDocument(new DataSet()
    {
      Tables = {
        CreateExcelFile.ListToDataTable<T>(list)
      }
    }, xlsxFilePath);

    public static DataTable ListToDataTable<T>(List<T> list)
    {
      DataTable dataTable = new DataTable();
      foreach (PropertyInfo property in typeof (T).GetProperties())
        dataTable.Columns.Add(new DataColumn(property.Name, CreateExcelFile.GetNullableType(property.PropertyType)));
      foreach (T obj in list)
      {
        DataRow row = dataTable.NewRow();
        foreach (PropertyInfo property in typeof (T).GetProperties())
        {
          if (!CreateExcelFile.IsNullableType(property.PropertyType))
            row[property.Name] = property.GetValue((object) obj, (object[]) null);
          else
            row[property.Name] = property.GetValue((object) obj, (object[]) null) ?? (object) DBNull.Value;
        }
        dataTable.Rows.Add(row);
      }
      return dataTable;
    }

    private static Type GetNullableType(Type t)
    {
      Type nullableType = t;
      if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof (Nullable<>)))
        nullableType = Nullable.GetUnderlyingType(t);
      return nullableType;
    }

    private static bool IsNullableType(Type type) => type == typeof (string) || type.IsArray || type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof (Nullable<>));

    public static bool CreateExcelDocument(DataTable dt, string xlsxFilePath)
    {
      DataSet ds = new DataSet();
      ds.Tables.Add(dt);
      bool excelDocument = CreateExcelFile.CreateExcelDocument(ds, xlsxFilePath);
      ds.Tables.Remove(dt);
      return excelDocument;
    }

    public static bool CreateExcelDocument(DataSet ds, string excelFilename)
    {
      try
      {
        using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Create(excelFilename, SpreadsheetDocumentType.Workbook))
          CreateExcelFile.WriteExcelFile(ds, spreadsheet);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    private static void WriteExcelFile(DataSet ds, SpreadsheetDocument spreadsheet)
    {
      spreadsheet.AddWorkbookPart();
      spreadsheet.WorkbookPart.Workbook = new Workbook();
      spreadsheet.WorkbookPart.Workbook.Append(new OpenXmlElement[1]
      {
        (OpenXmlElement) new BookViews(new OpenXmlElement[1]
        {
          (OpenXmlElement) new WorkbookView()
        })
      });
      spreadsheet.WorkbookPart.AddNewPart<WorkbookStylesPart>("rIdStyles").Stylesheet = new Stylesheet();
      uint num = 1;
      foreach (DataTable table in (InternalDataCollectionBase) ds.Tables)
      {
        string str = "rId" + num.ToString();
        string tableName = table.TableName;
        WorksheetPart worksheetPart = spreadsheet.WorkbookPart.AddNewPart<WorksheetPart>();
        worksheetPart.Worksheet = new Worksheet();
        worksheetPart.Worksheet.AppendChild<SheetData>(new SheetData());
        CreateExcelFile.WriteDataTableToExcelWorksheet(table, worksheetPart);
        worksheetPart.Worksheet.Save();
        if (num == 1U)
          spreadsheet.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
        spreadsheet.WorkbookPart.Workbook.GetFirstChild<Sheets>().AppendChild<Sheet>(new Sheet()
        {
          Id = (StringValue) spreadsheet.WorkbookPart.GetIdOfPart((OpenXmlPart) worksheetPart),
          SheetId = (UInt32Value) num,
          Name = (StringValue) table.TableName
        });
        ++num;
      }
      spreadsheet.WorkbookPart.Workbook.Save();
    }

    private static void WriteDataTableToExcelWorksheet(DataTable dt, WorksheetPart worksheetPart)
    {
      SheetData firstChild = worksheetPart.Worksheet.GetFirstChild<SheetData>();
      int count = dt.Columns.Count;
      bool[] flagArray = new bool[count];
      string[] strArray = new string[count];
      for (int columnIndex = 0; columnIndex < count; ++columnIndex)
        strArray[columnIndex] = CreateExcelFile.GetExcelColumnName(columnIndex);
      uint num = 1;
      Row excelRow1 = new Row()
      {
        RowIndex = (UInt32Value) num
      };
      firstChild.Append(new OpenXmlElement[1]
      {
        (OpenXmlElement) excelRow1
      });
      for (int index = 0; index < count; ++index)
      {
        DataColumn column = dt.Columns[index];
        CreateExcelFile.AppendTextCell(strArray[index] + "1", column.ColumnName, excelRow1);
        flagArray[index] = column.DataType.FullName == "System.Decimal" || column.DataType.FullName == "System.Int32";
      }
      foreach (DataRow row in (InternalDataCollectionBase) dt.Rows)
      {
        ++num;
        Row excelRow2 = new Row()
        {
          RowIndex = (UInt32Value) num
        };
        firstChild.Append(new OpenXmlElement[1]
        {
          (OpenXmlElement) excelRow2
        });
        for (int index = 0; index < count; ++index)
        {
          string str = row.ItemArray[index].ToString();
          if (flagArray[index])
          {
            double result = 0.0;
            if (double.TryParse(str, out result))
            {
              string cellStringValue = result.ToString();
              CreateExcelFile.AppendNumericCell(strArray[index] + num.ToString(), cellStringValue, excelRow2);
            }
          }
          else
            CreateExcelFile.AppendTextCell(strArray[index] + num.ToString(), str, excelRow2);
        }
      }
    }

    private static void AppendTextCell(string cellReference, string cellStringValue, Row excelRow)
    {
      Cell cell1 = new Cell();
      cell1.CellReference = (StringValue) cellReference;
      cell1.DataType = (EnumValue<CellValues>) CellValues.String;
      Cell cell2 = cell1;
      CellValue cellValue = new CellValue();
      cellValue.Text = cellStringValue;
      cell2.Append(new OpenXmlElement[1]
      {
        (OpenXmlElement) cellValue
      });
      excelRow.Append(new OpenXmlElement[1]
      {
        (OpenXmlElement) cell2
      });
    }

    private static void AppendNumericCell(
      string cellReference,
      string cellStringValue,
      Row excelRow)
    {
      Cell cell1 = new Cell();
      cell1.CellReference = (StringValue) cellReference;
      Cell cell2 = cell1;
      CellValue cellValue = new CellValue();
      cellValue.Text = cellStringValue;
      cell2.Append(new OpenXmlElement[1]
      {
        (OpenXmlElement) cellValue
      });
      excelRow.Append(new OpenXmlElement[1]
      {
        (OpenXmlElement) cell2
      });
    }

    private static string GetExcelColumnName(int columnIndex) => columnIndex < 26 ? ((char) (65 + columnIndex)).ToString() : string.Format("{0}{1}", (object) (char) (65 + columnIndex / 26 - 1), (object) (char) (65 + columnIndex % 26));
  }
}
