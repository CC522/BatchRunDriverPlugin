using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Microsoft.Office.Interop.Excel;

namespace DataHelper
{
    public class ExcelOpera
    {
        protected Microsoft.Office.Interop.Excel.Application objExcelApp;//定义Excel Application对象 
        private Microsoft.Office.Interop.Excel.Workbooks objExcelWorkBooks;//定义Workbook工作簿集合对象 
        protected Microsoft.Office.Interop.Excel.Workbook objExcelWorkbook;//定义Excel workbook工作簿对象 
        private Worksheet objExcelWorkSheet;//定义Workbook工作表对象 

        public List<String> GetExcelValuesList(string StrTestData)
        {
            objExcelApp = new Microsoft.Office.Interop.Excel.Application();
            objExcelWorkBooks = objExcelApp.Workbooks;
            objExcelWorkbook = objExcelWorkBooks.Open(StrTestData, 0, false, 5, "", "", true,
            Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

            //Open the Sheet 
            objExcelWorkSheet = (Worksheet)objExcelWorkbook.Worksheets["Global"]; //strSheetName是指的Exce工作簿的Sheet名，如果没有命名则为"1" 
            objExcelWorkSheet.Select(Type.Missing);

            //取得总记录行数   (包括标题列)
            int rowsint = objExcelWorkSheet.UsedRange.Cells.Rows.Count; //得到行数
            int columnsint = objExcelWorkSheet.UsedRange.Cells.Columns.Count;//得到列数

            string temp1 = ((Range)objExcelWorkSheet.Cells[1, 1]).Text.ToString();
            //遍历得到CompanyCode和TestAsset、Runtime
            int rowcolum = 0;
            List<String> str = new List<String>();

            for (int i = 1; i < columnsint; i++)
            {
                string strColumnsName = ((Range)objExcelWorkSheet.Cells[1, i]).Text.ToString();
                if (strColumnsName == "CompanyCode")
                {
                    rowcolum = i;//得到行号
                    String temp = ((Range)objExcelWorkSheet.Cells[2, i]).Text.ToString();
                    str.Add(((Range)objExcelWorkSheet.Cells[2, i]).Text.ToString());
                }
                if (strColumnsName == "SourceBoxName")
                {
                    rowcolum = i;//得到行号
                    String tempAssent = ((Range)objExcelWorkSheet.Cells[2, i]).Text.ToString();
                    string Asset = tempAssent.Substring(tempAssent.Length - 3);
                    str.Add(Asset);
                }

            }
            objExcelWorkbook.Close(false, StrTestData, false);
            objExcelApp.Quit();
            NAR(objExcelApp);
            NAR(objExcelWorkbook);
            NAR(objExcelWorkSheet);
            return str;
        }

        // 此函数用来释放对象的相关资源
        private void NAR(Object o)
        {
            try
            {
                //使用此方法，来释放引用某些资源的基础 COM 对象。 这里的o就是要释放的对象
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
            }
            catch { }
            finally
            {
                o = null; GC.Collect();
            }
        }
    }
}
