using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXUS.SCG.TOOLS
{
    public partial class WorkReportData
    {
        // シート名
        public string SheetName { set; get; } //set…値を取得 get…値を返す

        // 行データ
        public List<List<string>> RowData { set; get;}
    }
}
