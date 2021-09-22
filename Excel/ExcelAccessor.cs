using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace NEXUS.SCG.TOOLS
{
    public partial class ExcelAccessor : IDisposable
    {
        // Excelアプリケーション(COM)
        protected Excel.Application excelApp = null;

        // ワークブック
        protected Excel.Workbook workBook = null;


        public ExcelAccessor()
        {
            this.excelApp = new Excel.Application();
            this.excelApp.Visible = false;
        }


        public void Open(string filePath)
        {
            // ワークブックを開く
            this.workBook = (Excel.Workbook)(excelApp.Workbooks.Open(
                    filePath,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing));
        }

        public void Save()
        {
            // ワークブックを保存
            this.workBook.Save();
        }

        public void Close()
        {
            if (this.workBook != null)
            {
                // ワークブックを閉じる
                this.workBook.Close();
            }
        }

        public void Dispose()
        {

            // 警告無視設定
            this.excelApp.DisplayAlerts = false;

            // アプリケーションの終了
            this.excelApp.Quit();

            if (workBook != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(this.workBook);
                this.workBook = null;
            }

            if (excelApp != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(this.excelApp);
                this.excelApp = null;
            }
        }
    }
}
