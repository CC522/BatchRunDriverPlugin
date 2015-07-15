using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelper
{
    public class PublicFunction
    {
        public string strDriverPath(string StrTestData)
        {
            string strDriverPath;
            //get the Path for Driver
            int DriverEnd = StrTestData.LastIndexOf("\\fa_30_saptao_mec");
            String strDriverEnd = StrTestData.Substring(0, DriverEnd);
            strDriverPath = strDriverEnd + "\\fa_10_shared_resources\\00_Driver\\DriverData.xls";
            return strDriverPath;
        }
        //Get the Driver Script Path
        public string DriverPath(string StrTestData)
        {
            string DriverPath;
            int DriverEnd = StrTestData.LastIndexOf("\\fa_30_saptao_mec");
            String strDriverEnd = StrTestData.Substring(0, DriverEnd);
            DriverPath = strDriverEnd + "\\fa_10_shared_resources\\00_Driver\\Driver";
            return DriverPath;
        }
        public string strTemp(string StrTestData)
        {
            string strTemp;
            //get the path for OutPut or Temp
            int End = StrTestData.LastIndexOf("\\01_TestData");
            string strEnd = StrTestData.Substring(0, End);
            strTemp = strEnd + "\\03_TEMP\\Output.xlsx";
            return strTemp;
        }

        //get string for Test Data Path， and make Sure can Add to Driver.xls
        public string strTestDataPath(string StrTestData)
        {
            string strTestDataPath;
            //get StrTestDataPath for Driver.xls
            //  C:\APWFISVN\fa_30_saptao_mec\01_TestData\02_Fusion_EMEA\HPE\HPE_02001_FusionEMEA_TradeOrder_OEM_Eiffel_LH_AP_AR_IC.xls
            int End = StrTestData.LastIndexOf("\\01_TestData");
            int DataPathEnd = End + 13;
            strTestDataPath = StrTestData.Substring(DataPathEnd);
            return strTestDataPath;
        }

        //get the Name with out Extension , For Add to Driver.xls
        public string StrDataName(string StrTestData)  
        {
            //string strTestName = StrTestDataPath.Substring(StrTestDataPath.IndexOf('\\') + 1);

            //HPE_02001_FusionEMEA_TradeOrder_OEM_Eiffel_LH_AP_AR_IC    03001_FusionAPJ_TradeOrder_OEM_Eiffel_LH_AP_AR_IC - row1
            string filename = System.IO.Path.GetFileName(StrTestData);//文件名  “##### .xlsx”
            string extension = System.IO.Path.GetExtension(StrTestData);//扩展名 “.xlsx”
            string strfileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(StrTestData);// 没有扩展名的文件名 “#####”      
            int i = strfileNameWithoutExtension.IndexOf("0");
            string StrDataName = strfileNameWithoutExtension.Substring(i);
            return StrDataName;
        }
 
    }
}
