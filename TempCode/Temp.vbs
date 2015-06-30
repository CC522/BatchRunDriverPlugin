'Set fso=CreateObject("Scripting.FileSystemObject")
'Set fsoFolder=fso.GetFolder("C:\MEC\fa_30_saptao_mec\02_Report\02_FusionEMEA\HPE\Batch1")
'i=0
'For Each foldername In fsoFolder.SubFolders
'	If checkReg(foldername,".*\d{5}.*") Then
'		ReDim Preserve arrSubFolder(i)
'		arrSubFolder(i)=foldername
'		i=i+1
'	End If 
'Next
'MsgBox "asdfasdf"
Class TestInfoClass
	Public TestCaseNumber,TestAsset,TestCoCd,ReportName
		
	Function Exec
		arrReportName=Split(ReportName,"_",-1,1)
		'get case number and test asset
		For j=0 To UBound(arrReportName)
			If checkReg(arrReportName(j),"^\d{5}$") Then
				TestCaseNumber=arrReportName(j)
				TestAsset=arrReportName(j+1)
			End If 		
		Next
		'get company code
		For j=0 To UBound(arrReportName)
			If checkReg(arrReportName(j),"^[A-Za-z0-9]{4}$") Or checkReg(arrReportName(j),"^[A-Za-z0-9]{4}-[A-Za-z0-9]{4}$") Then
				TestCoCd=arrReportName(j)	
			End If 		
		Next
	End Function
End Class
Set TestInfo=New TestInfoClass
arrSubFolderNameList=GetSubFolderNameList("C:\MEC\fa_30_saptao_mec\02_Report\02_FusionEMEA\HPE\Batch1")
singleCoCd="Report_BE00_02006_FusionEMEA_CreditOrder_Eiffel_LH_AP_AR_IC_HPE_RunTime5_5-19-2015_3-06-44_PM"
MultiCoCd="Report_PR11-GB00_02001_FusionEMEA_TradeOrder_OEM_Eiffel_LH_AP_AR_IC_HPE_RunTime1_6-11-2015_1-47-29_PM"
'arrReportName=Split(MultiCoCd,"_",-1,1)
'get case number and test asset
'For j=0 To UBound(arrReportName)
'	If checkReg(arrReportName(j),"^\d{5}$") Then
'		TestCaseNumber=arrReportName(j)
'		TestAsset=arrReportName(j+1)
'	End If 		
'Next
'get company code
'For j=0 To UBound(arrReportName)
'	If checkReg(arrReportName(j),"^[A-Za-z0-9]{4}$") Or checkReg(arrReportName(j),"^[A-Za-z0-9]{4}-[A-Za-z0-9]{4}$") Then
'		TestCoCd=arrReportName(j)	
'	End If 		
'Next
TestInfo.ReportName=singleCoCd
TestInfo.Exec
a=testinfo.TestCaseNumber
b=testinfo.TestAsset
c=testinfo.TestCocd
MsgBox "asdfasdf"



Function GetTestCaseNumber
End Function
Function GetSubFolderNameList(parentFolderPath)
	Set fso=CreateObject("Scripting.FileSystemObject")
	Set fsoFolder=fso.GetFolder(parentFolderPath)
	i=0
	For Each foldername In fsoFolder.SubFolders
		If checkReg(foldername,".*\d{5}.*") Then
			ReDim Preserve arrSubFolder(i)
			arrSubFolder(i)=Right(foldername,Len(foldername)-Len(parentFolderPath)-1)
			i=i+1
		End If 
	Next
	GetSubFolderNameList=arrSubFolder
End Function


Function replaceReg(str,patrn,repstr)
	    Set re= New RegExp
	    re.Pattern=patrn
	    re.IgnoreCase=True
	    replaceReg=re.Replace(str,repstr)
End Function 
Function getReg(str,patrn)
	    Set re=New RegExp 
	    re.Pattern=patrn
	    re.IgnoreCase=True
	    re.Global=True
	    Set mhs=re.Execute(str)
	    Set getReg=mhs(0)
End Function
Function checkReg(str,patrn)
	    Set re=New RegExp 
	    re.Pattern=patrn
	    re.IgnoreCase=True
	    re.Global=True
	    checkReg=re.Test(str)
End Function