using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace NEXUS.SCG.TOOLS
{
    public partial class WorkReportAccessor : ExcelAccessor
    {
        // 読み取りの開始行
        private static readonly int START_ROW = 6;
        // 読み取りの開始列
        private static readonly int START_COL = 1;

        public List<string> GetSheetNames()
        {
            List<string> sheetNames = new List<string>();

            Excel.Sheets sheets = this.workBook.Worksheets;

            for (int i = 1; i < sheets.Count; i++)
            {
                Excel.Worksheet sheet = sheets[i] as Excel.Worksheet;
                sheetNames.Add(sheet.Name);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(sheets);

            return sheetNames;
        }

        public WorkReportData GetWorkReportData(string sheetName)
        {
            WorkReportData workReportData = new WorkReportData();
            workReportData.RowData = new List<List<string>>();

            Excel.Sheets sheets = this.workBook.Worksheets;
            Excel.Worksheet sheet = sheets[sheetName] as Excel.Worksheet;

            // シート名を取得
            workReportData.SheetName = sheet.Name;

            // 開始行/終了行
            int startRow = START_ROW;
            int startCol = START_COL;

            // 終了列の取得
            int endCol = 1;
            for (int col = 1; ; col++)
            {
                Excel.Range cell = sheet.Cells[START_ROW, col] as Excel.Range;
                string value = cell.Text;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(cell);

                if (value == null || value.Length == 0)
                {
                    break;
                }
                
                endCol++;
            }

            // 終了行の取得
            int endRow = START_ROW;
            for (int row = START_ROW; ; row++)
            {
                Excel.Range cell = sheet.Cells[row, START_COL] as Excel.Range;
                string value = cell.Text;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(cell);

                if (value == null || value.Length == 0)
                {
                    break;
                }

                endRow++;
            }

            // データの抽出
            for (int row = startRow; row < endRow; row++)
            {
                List<string> data = new List<string>();
                for (int col = startCol; col < endCol; col++)
                {
                    Excel.Range cell = sheet.Cells[row, col] as Excel.Range;
                    data.Add(cell.Text);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(cell);
                }

                workReportData.RowData.Add(data);
            }

            System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(sheets);

            return workReportData;
        }
    }
}
