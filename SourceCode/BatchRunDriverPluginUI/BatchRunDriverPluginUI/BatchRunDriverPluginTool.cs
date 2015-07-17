using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataHelper;
using System.IO;
using System.Diagnostics;

namespace BatchRunDriverPluginUI
{
    public partial class BatchRunDriverPluginTool : Form
    {
        public BatchRunDriverPluginTool()
        {
            InitializeComponent();
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "Please Choose One File";
            //fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileTestData = fileDialog.FileName;
                txtTestDataPath.Text = fileTestData;
            }
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "Please Choose One File";
            //fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileOutPut = fileDialog.FileName;
                txtOutputPath.Text = fileOutPut;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string StrTestData = txtTestDataPath.Text.Trim();
            //string strDriverPath;
            //string strTemp;
            if (StrTestData == String.Empty)
            {
             MessageBox.Show("Please Choose one file for TestData!", "Error");
             return;
            }
            if (cboRunTimeValues.Visible == false)
            {
                MessageBox.Show("Please Click Show RunTime to Choose RunTime for First Run!", "Error");
                return;
            }
            else
            {
               PublicFunction GetPath  = new PublicFunction();
               string strDriverPath = GetPath.strDriverPath(StrTestData);
               string strTempPath = GetPath.strTemp(StrTestData);
               string strTestDataPath = GetPath.strTestDataPath(StrTestData);

                //Get Driver Script Path
               string DriverScriptPath = GetPath.DriverPath(StrTestData);
               //Get the Driver Script path
               string DriverPath = GetPath.DriverPath(StrTestData);
               //Copy the OutPut into the Temp
               DirectoryInfo dir = new DirectoryInfo("Rescources");
               string StrPath = dir.Parent.Parent.Parent.FullName.ToString();
                //Get the Path of the vbs
               string tempVBSPath = StrPath + @"\Resources" + @"\" + "RunDriver.vbs";
                //Get the Path of the output
               string templateXlsPath = StrPath + @"\Resources" + @"\" + "Output.xlsx";
               //byte[] OutputXls = BatchRunResources.Output; 
               //FileStream outputExcelFile = new FileStream(templateXlsPath, FileMode.Create, FileAccess.Write); 
               //outputExcelFile.Write(OutputXls, 0, OutputXls.Length); 
               //outputExcelFile.Close(); 
               bool isrewrite = true; // true=覆盖已存在的同名文件,false则反之   Copy a New OutPut to the Temp 
               System.IO.File.Copy(templateXlsPath, strTempPath, isrewrite);

               //Get Data name 
               string strTestDataNameValue = GetPath.StrDataName(StrTestData);

               ExcelOpera GetData = new ExcelOpera();

               string StrRunTimeValue = cboRunTimeValues.SelectedValue.ToString();  // in the Last Version  we can Get the RunTime from Test Data to Add in Driver.xls
              //Get the Values that would be add in the Driver.xls
               List<String> StrExcelValues = GetData.GetExcelValuesList(StrTestData, StrRunTimeValue);
               string StrComCodeValue = StrExcelValues[0];
               string StrTestAssentValue = StrExcelValues[1];
               string StrTestCaseName = StrComCodeValue + "_" + strTestDataNameValue + "_" + StrTestAssentValue;
              
               GetData.InsertRowsValues(strDriverPath, StrTestCaseName, strTestDataPath, StrComCodeValue, StrTestAssentValue, StrRunTimeValue);

              //Run the Driver VBS 
               ProcessStartInfo startInfo = new ProcessStartInfo();
               startInfo.FileName = "wscript.exe";
               startInfo.Arguments = tempVBSPath + " " + DriverScriptPath;
               Process.Start(startInfo);
               cboRunTimeValues.Visible = false;
            }
        }

        private void btnReRun_Click(object sender, EventArgs e)
        {
            string StrTestData = txtTestDataPath.Text.Trim();
            string StrOutPutData =  txtOutputPath.Text.Trim();
            if (StrTestData == String.Empty)
            {
                MessageBox.Show("Please Choose one file for TestData!", "Error");
                return;
            }
            if (StrOutPutData == String.Empty)
            {
                MessageBox.Show("Please Choose one file for OutPut!", "Error");
                return;
            }
            else{

                ExcelOperation(StrTestData, StrOutPutData);

                //Get the Driver Script path
                PublicFunction GetDriverScriptPath = new PublicFunction();
                string DriverScriptPath = GetDriverScriptPath.DriverPath(StrTestData);
                DirectoryInfo dir = new DirectoryInfo("Rescources");
                string StrPath = dir.Parent.Parent.Parent.FullName.ToString();
                //Get the Path of the vbs
               string tempVBSPath = StrPath + @"\Resources" + @"\" + "RunDriver.vbs";
                //Run the Driver VBS 
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "wscript.exe";
                startInfo.Arguments = tempVBSPath +" "+DriverScriptPath;
                Process.Start(startInfo);
            }
        }

        private void btnMapping_Click(object sender, EventArgs e)
        {
            string StrTestData = txtTestDataPath.Text.Trim();
            string StrOutPutData = txtOutputPath.Text.Trim();
            if (StrTestData == String.Empty)
            {
                MessageBox.Show("Please Choose one file for TestData!", "Error");
                return;
            }
            if (StrOutPutData == String.Empty)
            {
                MessageBox.Show("Please Choose one file for OutPut!", "Error");
                return;
            }
            else
            {
                ExcelOperation(StrTestData, StrOutPutData);
                //Edit work Flow for Mapping 
                ExcelOpera GetData = new ExcelOpera();
                GetData.EditWorkFlow(StrTestData);
                //Get the Driver Script path
                PublicFunction GetDriverScriptPath = new PublicFunction();
                string DriverScriptPath = GetDriverScriptPath.DriverPath(StrTestData);
                DirectoryInfo dir = new DirectoryInfo("Rescources");
                string StrPath = dir.Parent.Parent.Parent.FullName.ToString();
                //Get the Path of the vbs
                string tempVBSPath = StrPath + @"\Resources" + @"\" + "RunDriver.vbs";
                //Run the Driver VBS 
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "wscript.exe";
                startInfo.Arguments = tempVBSPath + " " + DriverScriptPath;
                Process.Start(startInfo);
            }
        }

        public void ExcelOperation(string StrTestData, string StrOutPutData)
        {
            PublicFunction GetPath = new PublicFunction();
            //get Temp Path 
            string strTempPath = GetPath.strTemp(StrTestData);
            //Copy the OutPut into the Temp
            bool isrewrite = true; // true=覆盖已存在的同名文件,false则反之
            System.IO.File.Copy(StrOutPutData, strTempPath, isrewrite);

            //get DriverPath
            string strDriverPath = GetPath.strDriverPath(StrTestData);

            //Data for add to Driver.xls
            string strTestDataPath = GetPath.strTestDataPath(StrTestData);
            //Get Data name 
            string strTestDataNameValue = GetPath.StrDataName(StrTestData);

            //Get the Values that would be add in the Driver.xls
            ExcelOpera GetData = new ExcelOpera();
            string StrRunTimeValue = GetData.GetRunTimeVlaue(StrOutPutData);
            List<String> StrExcelValues = GetData.GetExcelValuesList(StrTestData, StrRunTimeValue);
            string StrComCodeValue = StrExcelValues[0];
            string StrTestAssentValue = StrExcelValues[1];
            string StrTestCaseName = StrComCodeValue + "_" + strTestDataNameValue + "_" + StrTestAssentValue;           
            GetData.InsertRowsValues(strDriverPath, StrTestCaseName, strTestDataPath, StrComCodeValue, StrTestAssentValue, StrRunTimeValue);
        }

        private void btnShowRunTime_Click(object sender, EventArgs e)
        {
            cboRunTimeValues.Visible = true;
            string StrTestData = txtTestDataPath.Text.Trim();
            if (StrTestData == String.Empty)
            {
                MessageBox.Show("Please Choose one file for TestData!", "Error");
                cboRunTimeValues.Visible = false;
                return;
            }
            ExcelOpera GetData = new ExcelOpera();
            List<string> strRunTimeForRun = GetData.GetRunTimeForRun(StrTestData);
            PublicFunction Function = new PublicFunction();
            List<string> strRunTimeValues = Function.getNewList(strRunTimeForRun);
            cboRunTimeValues.DataSource = strRunTimeValues;
        }

    }
}
