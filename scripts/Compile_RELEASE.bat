cd ..
C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\MSBuild HudsonTrayTracker\HudsonTrayTracker.sln ^
  /target:Rebuild ^
  /p:Configuration=Release
if not errorlevel 0 goto error
cd scripts


:error
@echo off
echo ####################################################
echo An error occured.
echo ####################################################
pause

:end
