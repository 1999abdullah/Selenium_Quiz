@ECHO OFF
ECHO Quiz Automation Executed Started.



set dllpath=C:\Users\samiiabd\source\repos\Selenium_Quiz\Selenium_Quiz\bin\Debug\Selenium_Quiz.dll
set trxerpath=C:\Users\samiiabd\source\repos\Selenium_Quiz\Selenium_Quiz\bin\Debug
set SummaryReportPath=C:\Users\samiiabd\source\repos\Selenium_Quiz\Selenium_Quiz\Summery

FOR /f %%a IN ('WMIC OS GET LocalDateTime ^| FIND "."') DO SET DTS=%%a
SET filename=%testcategory%_%DTS:~0,4%%DTS:~4,2%%DTS:~6,2%%DTS:~8,2%%DTS:~10,2%%DTS:~12,2%
echo %filename%

call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"


VSTest.Console.exe  %dllpath% /Logger:"trx;LogFileName=%SummaryReportPath%\%filename%\%filename%.trx"

cd %trxerpath%

TrxToHTML %SummaryReportPath%\%filename%\

PAUSE