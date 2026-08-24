

using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace PawnManagement
{
  internal class ExportToExcel
  {
    private static string fileName = "";
    private static int columnWidth = 20;
    private static int rowWidth = 15;

    public static void setWidth(int rowwidth, int colWidth)
    {
      ExportToExcel.columnWidth = colWidth;
      ExportToExcel.rowWidth = rowwidth;
    }

    public static void exportToExcel(System.Data.DataTable dt, string sheetName, string password)
    {
      object obj = (object) Missing.Value;
      Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application) new ApplicationClass();
      application.Visible = false;
      Workbook workbook = application.Workbooks.Add((object) XlWBATemplate.xlWBATWorksheet);
      Worksheet activeSheet = (Worksheet) workbook.ActiveSheet;
      activeSheet.Columns.ColumnWidth = (object) ExportToExcel.columnWidth;
      activeSheet.Rows.RowHeight = (object) ExportToExcel.rowWidth;
      for (int index = 0; index < dt.Columns.Count; ++index)
      {
        activeSheet.Cells[(object) 1, (object) (index + 1)] = (object) dt.Columns[index].ColumnName;
        activeSheet.Name = sheetName;
      }
      for (int index = 0; index < dt.Rows.Count; ++index)
      {
        for (int columnIndex = 0; columnIndex < dt.Columns.Count; ++columnIndex)
          activeSheet.Cells[(object) (index + 2), (object) (columnIndex + 1)] = (object) dt.Rows[index][columnIndex].ToString();
      }
      workbook.SaveAs((object) (ExportToExcel.fileName + DateTime.Now.ToLongDateString()), (object) XlFileFormat.xlWorkbookNormal, (object) password, obj, obj, obj, XlSaveAsAccessMode.xlExclusive, obj, obj, obj, obj, obj);
      workbook.Close((object) true, obj, obj);
      application.Quit();
    }

    public static void exportToExcel(DataGridView dgv, string sheetName, string password)
    {
      object obj = (object) Missing.Value;
      Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application) new ApplicationClass();
      application.Visible = true;
      Workbook workbook = application.Workbooks.Add((object) XlWBATemplate.xlWBATWorksheet);
      Worksheet activeSheet = (Worksheet) workbook.ActiveSheet;
      activeSheet.Columns.ColumnWidth = (object) ExportToExcel.columnWidth;
      activeSheet.Rows.RowHeight = (object) ExportToExcel.rowWidth;
      for (int index = 0; index < dgv.Columns.Count; ++index)
      {
        activeSheet.Cells[(object) 1, (object) (index + 1)] = (object) dgv.Columns[index].HeaderText;
        activeSheet.Name = sheetName;
      }
      for (int index1 = 0; index1 < dgv.Rows.Count; ++index1)
      {
        for (int index2 = 0; index2 < dgv.Columns.Count; ++index2)
        {
          if (dgv.Rows[index1].Cells[index2].Value != null)
            activeSheet.Cells[(object) (index1 + 2), (object) (index2 + 1)] = (object) dgv.Rows[index1].Cells[index2].Value.ToString();
        }
      }
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = "Desktop";
      saveFileDialog.FileName = sheetName + DateTime.Now.ToLongDateString();
      saveFileDialog.Filter = "Excel2003|*.xls|Excel2007|*.xlsx";
      if (DialogResult.OK == saveFileDialog.ShowDialog())
      {
        ExportToExcel.fileName = saveFileDialog.FileName;
        if (File.Exists(ExportToExcel.fileName))
          File.Delete(ExportToExcel.fileName);
        workbook.SaveAs((object) ExportToExcel.fileName, (object) XlFileFormat.xlWorkbookNormal, (object) password, obj, obj, obj, XlSaveAsAccessMode.xlExclusive, obj, obj, obj, obj, obj);
        workbook.Close((object) true, obj, obj);
        application.Quit();
      }
      else
      {
        workbook.Saved = true;
        application.Quit();
      }
    }

    public static void exportToExcelandPrint(DataGridView dgv, string sheetName, string password)
    {
      object obj = (object) Missing.Value;
      Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application) new ApplicationClass();
      application.Visible = true;
      Workbook workbook = application.Workbooks.Add((object) XlWBATemplate.xlWBATWorksheet);
      Worksheet activeSheet = (Worksheet) workbook.ActiveSheet;
      activeSheet.Columns.ColumnWidth = (object) ExportToExcel.columnWidth;
      activeSheet.Rows.RowHeight = (object) ExportToExcel.rowWidth;
      for (int index = 0; index < dgv.Columns.Count; ++index)
      {
        activeSheet.Cells[(object) 1, (object) (index + 1)] = (object) dgv.Columns[index].HeaderText;
        activeSheet.Name = sheetName;
      }
      for (int index1 = 0; index1 < dgv.Rows.Count; ++index1)
      {
        for (int index2 = 0; index2 < dgv.Columns.Count; ++index2)
        {
          if (dgv.Rows[index1].Cells[index2].Value != null)
            activeSheet.Cells[(object) (index1 + 2), (object) (index2 + 1)] = (object) dgv.Rows[index1].Cells[index2].Value.ToString();
        }
      }
      workbook.PrintOutEx((object) 1, (object) 2, (object) 1, obj, obj, obj, obj, obj, obj);
      application.Quit();
    }
  }
}
