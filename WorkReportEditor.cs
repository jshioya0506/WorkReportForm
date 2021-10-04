using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXUS.SCG.TOOLS
{
    public partial class WorkReportEditor : Form
    {
        public WorkReportEditor()
        {
            InitializeComponent();
        }

        #region イベントハンドラ

        private void WorkReportEditor_Load(object sender, EventArgs e)
        {
            // ツールチップの設定
            toolTip1.SetToolTip(this.btnOpenFile, "勤務形態管理表を開く");
            toolTip1.SetToolTip(this.btnSaveFile, "勤務形態管理表を保存");
            toolTip1.SetToolTip(this.btnImportCsv, "インポート(CSV)");
            toolTip1.SetToolTip(this.btnExportCsv, "エクスポート(CSV)");
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            // ファイルを開くダイアログを表示
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excelファイル|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            // 取得したファイル名を画面に表示
            this.lblFileName.Text = Path.GetFileName(openFileDialog.FileName);

            // Excelファイルをオープンし、勤怠管理情報(WorkReportData)を取得
            WorkReportData reportData = null;
            using (WorkReportAccessor accessor = new WorkReportAccessor())
            {
                // Excelファイルを開く
                accessor.Open(openFileDialog.FileName);

                // 勤怠情報のシート一覧を取得し、コンボボックスに設定
                List<string> sheetNames = accessor.GetSheetNames();
                foreach (string sheetName in sheetNames)
                {
                    this.cbxExcelSheets.Items.Add(sheetName);
                }

                // 先頭シートを選択
                string initSheetName = this.cbxExcelSheets.Items[0] as string;
                this.cbxExcelSheets.SelectedIndex = 0;

                // 勤怠予実データを読み込み
                reportData = accessor.GetWorkReportData(initSheetName);

                // Excelファイルを閉じる
                accessor.Close();
            }

            if (reportData == null)
            {
                return;
            }

            // ファイルを開き、Excelデータを表示
            ShowData(reportData);
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            // ファイルを保存ダイアログを開く
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excelファイル|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            // ファイルを開き、Excelへ保存
            SaveData(saveFileDialog.FileName);
        }

        private void btnImportCsv_Click(object sender, EventArgs e)
        {

            //open
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // デフォルトのフォルダを指定する
            openFileDialog.InitialDirectory = @"C:";

            //ダイアログのタイトルを指定する
             //openFileDialog.Title = "ダイアログのタイトル";

             //ダイアログを表示する
             if (openFileDialog.ShowDialog() == DialogResult.Cancel)     
             {
                Console.WriteLine("キャンセルされました");
                return;
             }

            // 保存先ファイルパスを取得
            string csvFilePath = openFileDialog.FileName;

            //保存先ファイルパスがcsvでなかったとき終了
            string file_ext;
            file_ext = Path.GetExtension(csvFilePath);
            if (file_ext != ".csv") 
            {
                return;
            }

            // StreamReaderクラスをインスタンス化
            StreamReader reader = new StreamReader(csvFilePath, Encoding.GetEncoding("UTF-8"));

            //CSVファイルの中身を読み込み

            // WorkReportDataクラスをインスタンス化
            WorkReportData newData = new WorkReportData();
            newData.RowData = new List<List<string>>();



            // 最後まで読み込む
            while (reader.Peek() > -1)
            {
                List<string> values = new List<string>();
                // 読み込んだ文字列をカンマ区切りで配列に格納
                string[] cols = reader.ReadLine().Split(',');
                for (int n = 0; n < cols.Length; n++)
                {
                    // 表示
                    Console.WriteLine(cols[n] + ",");
                    //valuesへ値を格納
                    values.Add(cols[n]);

                }
                newData.RowData.Add(values);
            }
  
            newData.SheetName = Path.GetFileNameWithoutExtension(csvFilePath);

            //勤務形態管理のデータオブジェクトを生成する

            // オブジェクトを破棄する
            openFileDialog.Dispose();

        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            // 保存先ファイルパスを選択
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSVファイル|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            // 保存先ファイルパスを取得
            string csvFilePath = saveFileDialog.FileName;

            // テーブルのレポートデータを取得
            WorkReportData newData = new WorkReportData();
            newData.RowData = new List<List<string>>();
            for (int rowNo = 0; rowNo < this.WorkDataGridView.Rows.Count; rowNo++)
            {
                List<string> values = new List<string>();
                for (int colNo = 0; colNo < this.WorkDataGridView.Columns.Count; colNo++)
                {
                    string value = this.WorkDataGridView.Rows[rowNo].Cells[colNo].Value as string;
                    values.Add(value);
                }
                newData.RowData.Add(values);
            }
            newData.SheetName = this.cbxExcelSheets.Text;

            // CSVへインポート
            CsvExporter csvExporter = new CsvExporter();
            csvExporter.ExportCsv(csvFilePath, newData);

        }
        #endregion イベントハンドラ

        #region メソッド
        private void ShowData(WorkReportData reportData)
        {
            // 勤怠予実データをデータグリッドに表示
            this.WorkDataGridView.ColumnCount = reportData.RowData[0].Count;
            this.WorkDataGridView.RowCount = reportData.RowData.Count;

            int rowNo = 0;
            foreach (List<string> columns in reportData.RowData)
            {
                int colNo = 0;
                foreach (string columnValue in columns)
                {
                    this.WorkDataGridView.Rows[rowNo].Cells[colNo].Value = columnValue;
                    this.WorkDataGridView.Rows[rowNo].Cells[colNo].Style.ForeColor = Color.Black;
                    this.WorkDataGridView.Rows[rowNo].Cells[colNo].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colNo++;
                }
                rowNo++;
            }

            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            //this.WorkDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            this.WorkDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void SaveData(string fileName)
        {
            // 表示中のシートを取得

            // 編集したテーブルデータを取得

            // 編集したテーブルデータをExcelへ保存
        }

        private DataGridViewColumn CreateDataGridViewTextBoxColumn(string name, string header, int width, Type type)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = name;
            col.DataPropertyName = name;
            col.HeaderText = header;
            col.ValueType = type;
            col.Width = width;
            return col;
        }

        #endregion メソッド
    }
}