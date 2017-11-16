@Echo Off

REM This is a script that will set environment information about where to find
REM NuGet.exe, it's version and ensure that it's present on the enlistment.
Set NuGetExeFolder=%~dp0..
Set NuGetExe=%NuGetExeFolder%\NuGet.exe
Set NuGetAdditionalCommandLineArgs=-verbosity quiet -configfile "%NuGetExeFolder%\nuget.config"

REM Download NuGet.exe if we haven't already
powershell -noprofile -executionPolicy RemoteSigned -file "%~dp0download-nuget.ps1" 
