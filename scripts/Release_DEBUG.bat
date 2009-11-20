if not exist "%NSIS%" goto error_Environment

call Compile_DEBUG.bat
if not errorlevel 0 goto error

cd installer
"%NSIS%\makensis" HudsonTrayTracker_DEBUG.nsi
if not errorlevel 0 goto error

pause
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
