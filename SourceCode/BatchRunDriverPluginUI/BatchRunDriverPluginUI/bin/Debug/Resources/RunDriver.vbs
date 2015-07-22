set objArgs = wscript.Arguments
TestPath=objArgs(0)
Set app=CreateObject("QuickTest.Application")
app.SetActiveAddins Array("SAP","Web",".NET")
If Not app.Launched Then
	app.Launch
Else
	app.Quit
	wait 10
	app.Launch
End If
app.Visible=True
app.Open TestPath
Set qtResultsOpt = CreateObject("QuickTest.RunResultsOptions")
qtResultsOpt.ResultsLocation = "<TempLocation>"
app.Test.Run qtResultsOpt,True
app.Quit