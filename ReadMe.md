## DriverRunPlugIn Tool ##


### Introduce ###

1.	Help to add data in driver file

2.	Trigger driver file to run case after data added completely

3.	Trigger driver file to run mapping execution without update input manually


### How to use ###
####1: Run  ####

**Step1:**Click the Browse ,Choose Test Data Path for the Test Data you want to Run
![FilesInGit](https://raw.githubusercontent.com/CC522/BatchRunDriverPlugin/master/Image/Run-Step1.jpg)


**Step2:**Click the Button"Show Run Time", There would be Show the RunTimes in the TestData ,you could Choose the RunTime you want to Run
![FilesInGit](https://raw.githubusercontent.com/CC522/BatchRunDriverPlugin/master/Image/Run-Step2.jpg)

**Step3:**Click the Run

**Note:** When you Run the Script for the Test Data First Time ,You don't need to select the OutPut path. When you Click the Run ,The Program will add a new Row in the Driver.xls and Copy a new [OutPut.xlsx](https://github.com/CC522/BatchRunDriverPlugin/blob/master/SourceCode/BatchRunDriverPluginUI/BatchRunDriverPluginUI/Resources/Output.xlsx) in the temp Floder. And Call [RunDriver.vbs](https://github.com/CC522/BatchRunDriverPlugin/blob/master/SourceCode/BatchRunDriverPluginUI/BatchRunDriverPluginUI/Resources/RunDriver.vbs) to Open the UFT and Run the Script.
####2: ReRun ####

**Step1:**Click the Browse ,Choose Test Data Path for the Test Data you want to Run

**Step2:**Click the Browse ,Choose OutPut.xls which generated by last time to Run the TestData you Selected

**Step3:**Click the ReRun 
![FilesInGit](https://raw.githubusercontent.com/CC522/BatchRunDriverPlugin/master/Image/ReRun.jpg)

**Note:** When you click the Rerun ,You don't need to select the runTime,Program will get the runtime from the output.xls. When you click the button"ReRun",the Program will add a new Row in the Driver.xls and Copy the output.xls  to the temp Floder from the Outpath you Selected.

####3: Mapping ####

**The same operation as ReRun**.

**Notes:** Same as ReRun,The only difference is when you click the Mapping , The Program will be Edit the Test Data ,it will only run the WorkFlow for Mapping.

