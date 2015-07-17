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

        public List<String> GetExcelValuesList(string StrTestData,string StrRuntime)
        {
            objExcelApp = new Microsoft.Office.Interop.Excel.Application();
            objExcelWorkBooks = objExcelApp.Workbooks;
            objExcelWorkbook = objExcelWorkBooks.Open(StrTestData, 0, false, 5, "", "", true,
            Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

            //Open the Sheet 
            objExcelWorkSheet = (Worksheet)objExcelWorkbook.Worksheets["Global"]; //Exce工作簿的Sheet
            objExcelWorkSheet.Select(Type.Missing);

            //取得总记录行数   (包括标题列)
            int rowsint = objExcelWorkSheet.UsedRange.Cells.Rows.Count; //得到行数
            int columnsint = objExcelWorkSheet.UsedRange.Cells.Columns.Count;//得到列数

            string temp1 = ((Range)objExcelWorkSheet.Cells[1, 1]).Text.ToString();
            //遍历得到CompanyCode和TestAsset
            int rowcolum = 0;
            int RowID = 0;
            List<String> str = new List<String>();

            for (int i = 1; i <= columnsint; i++)
            {
                string strColumnsName = ((Range)objExcelWorkSheet.Cells[1, i]).Text.ToString();
                if (strColumnsName == "RunTime")
                {
                    rowcolum = i;//Get the columm no
                    for (int j = 1; j <= rowsint;j++ )
                    {
                        string strRowValue = ((Range)objExcelWorkSheet.Cells[j, i]).Text.ToString();
                        if(strRowValue == StrRuntime)
                        {
                            RowID = j;
                        }
                    }
                }
                  if (strColumnsName == "CompanyCode")
                 {
                      rowcolum = i;//得到Column号
                      String temp = ((Range)objExcelWorkSheet.Cells[RowID, i]).Text.ToString();
                      str.Add(((Range)objExcelWorkSheet.Cells[RowID, i]).Text.ToString());
                  }
                  if (strColumnsName == "TargetBoxName")
                 {
                      rowcolum = i;//得到行号
                      String tempAssent = ((Range)objExcelWorkSheet.Cells[RowID, i]).Text.ToString();
                      string Asset = tempAssent.Substring(tempAssent.Length - 3);
                      str.Add(Asset);
                   }
                }
                //if (strColumnsName == "CompanyCode")
                //{
                //    rowcolum = i;//得到Column号
                //    String temp = ((Range)objExcelWorkSheet.Cells[2, i]).Text.ToString();
                //    str.Add(((Range)objExcelWorkSheet.Cells[2, i]).Text.ToString());
                //}
                //if (strColumnsName == "TargetBoxName")
                //{
                //    rowcolum = i;//得到行号
                //    String tempAssent = ((Range)objExcelWorkSheet.Cells[2, i]).Text.ToString();
                //    string Asset = tempAssent.Substring(tempAssent.Length - 3);
                //    str.Add(Asset);
                //}
            objExcelWorkbook.Close(false, StrTestData, false);
            objExcelApp.Quit();
            NAR(objExcelApp);
            NAR(objExcelWorkbook);
            NAR(objExcelWorkSheet);
            return str;
        }


        // Get the RunTime Values for ReRun & Mapping 
        public string GetRunTimeVlaue(string StrOutputPath)
        {
            objExcelApp = new Microsoft.Office.Interop.Excel.Application();
            objExcelWorkBooks = objExcelApp.Workbooks;
            objExcelWorkbook = objExcelWorkBooks.Open(StrOutputPath, 0, false, 5, "", "", true,
            Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

            //Open the Sheet 
            objExcelWorkSheet = (Worksheet)objExcelWorkbook.Worksheets["Output"]; //Exce工作簿的Sheet
            objExcelWorkSheet.Select(Type.Missing);

            //取得总记录行数   (包括标题列)
            int rowsint = objExcelWorkSheet.UsedRange.Cells.Rows.Count; //得到行数
            int columnsint = objExcelWorkSheet.UsedRange.Cells.Columns.Count;//得到列数

            string temp1 = ((Range)objExcelWorkSheet.Cells[1, 1]).Text.ToString();
            //遍历得到CompanyCode和TestAsset、Runtime
            int rowcolum = 0;
            for (int i = 1; i <= columnsint; i++)
            {
                string strColumnsName = ((Range)objExcelWorkSheet.Cells[1, i]).Text.ToString();
                if (strColumnsName == "RunTime")
                {
                    rowcolum= i;//得到Colum号                   
                }
            }
            String RunTimeValues = ((Range)objExcelWorkSheet.Cells[rowsint,rowcolum]).Text.ToString();
            objExcelWorkbook.Close(false, StrOutputPath, false);
            objExcelApp.Quit();
            NAR(objExcelApp);
            NAR(objExcelWorkbook);
            NAR(objExcelWorkSheet);
            return RunTimeValues;
        }
       
        // Insert Row in the Driver.xls
        public void InsertRowsValues(string StrDriverPath, string StrCaseName, string StrTestDataPath, string StrComCode, string StrAsset, string StrRunTime)
        {
            objExcelApp = new Microsoft.Office.Interop.Excel.Application();
            objExcelWorkBooks = objExcelApp.Workbooks;
            objExcelWorkbook = objExcelWorkBooks.Open(StrDriverPath, 0, false, 5, "", "", true,
            Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

            objExcelWorkSheet = (Worksheet)objExcelWorkbook.Worksheets["Driver"]; //strSheetName是指的Exce工作簿的Sheet名，如果没有命名则为"1" 
            objExcelWorkSheet.Select(Type.Missing);
            int rowsint = objExcelWorkSheet.UsedRange.Cells.Rows.Count; //得到行数
            if (rowsint > 1)
            {
                for (int i = 2; i <= rowsint; i++)
                {
                    string strFlagValue = ((Range)objExcelWorkSheet.Cells[i, 1]).Text.ToString();
                    if (strFlagValue == "Y")
                    {
                         int RowNO = i;
                         objExcelWorkSheet.Cells[RowNO, 1] = "N";
                    }
                }
            }
            if (rowsint == 1)
            {
                rowsint = 2;
            }
            objExcelWorkSheet.Cells[rowsint, 1] = "Y";
            objExcelWorkSheet.Cells[rowsint, 2] = "fa_30_saptao_mec";
            objExcelWorkSheet.Cells[rowsint, 3] = StrRunTime;
            objExcelWorkSheet.Cells[rowsint, 4] = StrRunTime;
            objExcelWorkSheet.Cells[rowsint, 5] = StrCaseName;
            objExcelWorkSheet.Cells[rowsint, 6] = StrTestDataPath;
            objExcelWorkSheet.Cells[rowsint, 7] = "Run";
            objExcelWorkSheet.Cells[rowsint, 8] = StrComCode;
            objExcelWorkSheet.Cells[rowsint, 9] = StrAsset;
            objExcelWorkbook.Save();

            objExcelWorkbook.Close(false, StrDriverPath, false);
            objExcelApp.Quit();
            NAR(objExcelApp);
            NAR(objExcelWorkbook);
            NAR(objExcelWorkSheet);
        }
        // Get The RunTime For First Run @2015-7-16 by CC
        public List<String> GetRunTimeForRun(string  StrTestData)
        { 
            objExcelApp = new Microsoft.Office.Interop.Excel.Application();
            objExcelWorkBooks = objExcelApp.Workbooks;
            objExcelWorkbook = objExcelWorkBooks.Open(StrTestData, 0, false, 5, "", "", true,
            Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

            //Open the Sheet 
            objExcelWorkSheet = (Worksheet)objExcelWorkbook.Worksheets["Global"]; //Exce工作簿的Sheet
            objExcelWorkSheet.Select(Type.Missing);

            //取得总记录行数   (包括标题列)
            int rowsint = objExcelWorkSheet.UsedRange.Cells.Rows.Count; //得到行数
            int columnsint = objExcelWorkSheet.UsedRange.Cells.Columns.Count;//得到列数

            string temp1 = ((Range)objExcelWorkSheet.Cells[1, 1]).Text.ToString();
            //遍历得到RunTime
            int rowcolum = 0;
            List<String> str = new List<String>();
            for (int i = 1; i <= columnsint; i++)
            {
                string strColumnsName = ((Range)objExcelWorkSheet.Cells[1, i]).Text.ToString();
                if (strColumnsName == "RunTime")
                {
                    rowcolum = i;//Get Column No 
                    for (int j = 2; j <= rowsint; j++)
                    {
                        string StrRunTimeValue = ((Range)objExcelWorkSheet.Cells[j, i]).Text.ToString();
                        str.Add(StrRunTimeValue);
                    }
                }
            }
            objExcelWorkbook.Close(false, StrTestData, false);
            objExcelApp.Quit();
            NAR(objExcelApp);
            NAR(objExcelWorkbook);
            NAR(objExcelWorkSheet);
            return str;
        }

        // Change the Mapping WorkFlow  @2015-7-16 By CC
        public void EditWorkFlow(string StrTestData)
        {
            objExcelApp = new Microsoft.Office.Interop.Excel.Application();
            objExcelWorkBooks = objExcelApp.Workbooks;
            objExcelWorkbook = objExcelWorkBooks.Open(StrTestData, 0, false, 5, "", "", true,
            Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

            objExcelWorkSheet = (Worksheet)objExcelWorkbook.Worksheets["WorkFlow"]; //strSheetName是指的Exce工作簿的Sheet名，如果没有命名则为"1" 
            objExcelWorkSheet.Select(Type.Missing);
            int rowsint = objExcelWorkSheet.UsedRange.Cells.Rows.Count; //得到行数
            int columnsint = objExcelWorkSheet.UsedRange.Cells.Columns.Count;//得到列数
            int rowNo = 0;
            int ParameterRowNo = 0;
            int columnNo = 0;
            int FlagColumnNo = 0;
            for (int j = 1; j <= columnsint; j++)
            {
                string strColumnsName = ((Range)objExcelWorkSheet.Cells[1, j]).Text.ToString();
                if (strColumnsName == "Flag")
                {
                    FlagColumnNo = j;
                }
                if (strColumnsName == "BusinessFlow")
                {
                    rowNo = j;
                }
                if (strColumnsName == "ParameterValue")
                {
                    ParameterRowNo = j;
                }
            }
            for (int i = 2; i <= rowsint; i++)
            {
                string strFlagValue = ((Range)objExcelWorkSheet.Cells[i, FlagColumnNo]).Text.ToString();
                if (strFlagValue =="Y")
                {
                    int RowNO = i;
                    objExcelWorkSheet.Cells[RowNO, FlagColumnNo] = "N";
                }
               string strBusinessFlow = ((Range)objExcelWorkSheet.Cells[i, rowNo]).Text.ToString();
               if (strBusinessFlow == "HeaderMapping" || strBusinessFlow == "TaxMapping" || strBusinessFlow == "LineItemsMapping")
               {
                 columnNo = i;
                 string strParameterValue = ((Range)objExcelWorkSheet.Cells[i, ParameterRowNo]).Text.ToString();
                 if (strParameterValue == "IR" || strParameterValue == "TradeBilling" || strParameterValue == "TradeCredit" || strParameterValue == "TradeDebit" || strParameterValue == "TradeReturn")
                  {
                    objExcelWorkSheet.Cells[i, 1] = "Y";
                  }
                }
            }
            objExcelWorkbook.Save();
            objExcelWorkbook.Close(false, StrTestData, false);
            objExcelApp.Quit();
            NAR(objExcelApp);
            NAR(objExcelWorkbook);
            NAR(objExcelWorkSheet);
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
