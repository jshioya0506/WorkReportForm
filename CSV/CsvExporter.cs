using System;
using System.Collections.Generic;
using System.IO; //StreamWriterクラスを使うため
using System.Linq;
using System.Text; //Encoding.UTF8の定数を使うため
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXUS.SCG.TOOLS
{
    public partial class CsvExporter
    {
        public void ExportCsv(string csvFilePath, WorkReportData reportData)
        {
            // 出力ストリームを開く // ファイルを書き込みモード（上書き）で開く

            try
            {
                using (StreamWriter file = new StreamWriter(csvFilePath, false, Encoding.UTF8)) //StreamWriter(ファイルパス,上書き,エンコード);
                {
                    // file.WriteLine("apple" + "," + "りんご"); // レポートデータを出力ストリームへ書き込み

                    // シート名を取得
                    // file.WriteLine(reportData.SheetName);  //file.WriteLine("apple" + "," + "りんご"); // 1行目　　："シート名"
                    //file.WriteLine("おはよう");     // 2行目　　："月日","曜日","メンバー名1",...,"メンバー名" エクセルの6列目のデータ
                    //file.WriteLine("おはよう");     // 3行目以降：実際のデータ
                    // ファイルへ出力
                    foreach (List<string> columns in reportData.RowData)
                    {
                        foreach (string column in columns)
                        {
                            file.Write(column + ",");
                        }
                        file.WriteLine(); //改行
                    }

                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
