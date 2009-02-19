if not exist "%NSIS%" goto error_Environment

cd ..
C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\MSBuild HudsonTrayTracker\HudsonTrayTracker.sln" ^
  /target:Rebuild ^
  /p:Configuration=Release
if not errorlevel 0 goto error
cd scripts

cd installer
"%NSIS%\makensis" HudsonTrayTracker.nsi
if not errorlevel 0 goto error

goto end

:error_Environment
@echo off
echo ####################################################
echo Environment variable NSIS has not been set
echo ####################################################
pause
goto error

:error
@echo off
echo ####################################################
echo An error occured.
echo ####################################################
pause

:end
