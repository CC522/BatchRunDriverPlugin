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
            }
            else {
            //    // FilePath:  C:\APWFISVN\fa_30_saptao_mec\01_TestData\02_Fusion_EMEA\HPE
            //    //Temp :     C:\APWFISVN\fa_30_saptao_mec\03_TEMP
            //    //OutPut:   C:\APWFISVN\fa_30_saptao_mec\02_Report\02_FusionEMEA\HPE\Batch1\Report_TR01_02006_FusionEMEA_CreditOrder_Eiffel_LH_AP_AR_IC_HPE_RunTime1_5-20-2015_11-46-34_AM
            //    //Driver:   C:\APWFISVN\fa_10_shared_resources\00_Driver

               PublicFunction GetPath  = new PublicFunction();
               string strDriverPath = GetPath.strDriverPath(StrTestData);
               string strTempPath = GetPath.strTemp(StrTestData);
               string strTestDataPath = GetPath.strTestDataPath(StrTestData);

            }
        }

        private void btnReRun_Click(object sender, EventArgs e)
        {
            string StrTestData = txtTestDataPath.Text.Trim();
            string StrOutPutData =  txtOutputPath.Text.Trim();
            if (StrTestData == String.Empty)
            {
                MessageBox.Show("Please Choose one file for TestData!", "Error");
            }
            if (StrOutPutData == String.Empty)
            {
                MessageBox.Show("Please Choose one file for OutPut!", "Error");
            }
            else{
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

                ExcelOpera GetData = new ExcelOpera();
               // List<String> StrTestDataValue = GetData.getExcelCompanyCode(StrTestData);
                List<String> StrExcelValues = GetData.GetExcelValuesList(StrTestData);
                string StrComCodeValue = StrExcelValues[0];
                string StrTestAssentValue = StrExcelValues[1];
               // string StrCompanyCode = GetData.getExcelCompanyCode(StrTestData);
                //string StrTestAsset = GetData.getExcelTestAsset(StrTestData,2,4);
                string StrTestCaseName = StrComCodeValue + "_" + strTestDataNameValue + "_" + StrTestAssentValue;
            }
        }

        private void btnMapping_Click(object sender, EventArgs e)
        {
            string StrTestData = txtTestDataPath.Text.Trim();
            string StrOutPutData = txtOutputPath.Text.Trim();
            if (StrTestData == String.Empty)
            {
                MessageBox.Show("Please Choose one file for TestData!", "Error");
            }
            if (StrOutPutData == String.Empty)
            {
                MessageBox.Show("Please Choose one file for OutPut!", "Error");
            }
            else
            {
                PublicFunction GetData = new PublicFunction();
                string strTempPath = GetData.strTemp(StrTestData);
                //Copy the OutPut into the Temp
                bool isrewrite = true; // true=覆盖已存在的同名文件,false则反之
                System.IO.File.Copy(StrOutPutData, strTempPath, isrewrite);
            }
        }

    }
}
