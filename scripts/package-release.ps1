<#
.SYNOPSIS
A PowerShell script to package and releasify Jenkins Tray.
#>
[CmdletBinding(PositionalBinding = $false)]
param (
    [Parameter(Mandatory=$true)]
    [ValidateNotNullOrEmpty()]
    [string]$repoRoot,
    [ValidateNotNullOrEmpty()]
    [string]$versionjson = "$repoRoot\version.json",
    [ValidateNotNullOrEmpty()]
    [string]$nuspec = "$repoRoot\JenkinsTray.nuspec",
    [ValidateNotNullOrEmpty()]
    [string]$outputPath = "$repoRoot\JenkinsTray\bin\x86\Release",
    [parameter(ValueFromRemainingArguments = $true)] $badArgs)

#Requires -Version 3.0
$ErrorActionPreference="Stop"

try {
    if (!(Test-Path $repoRoot -PathType Container)) {
        Write-Error "$repoRoot does not exist. Aborting."
    }
    if (!(Test-Path $versionjson -PathType Leaf)) {
        Write-Error "$versionjson does not exist. Aborting."
    }
    if (!(Test-Path $nuspec -PathType Leaf)) {
        Write-Error "$nuspec does not exist. Aborting."
    }
    if (!(Test-Path $outputPath -PathType Container)) {
        Write-Error "$outputPath does not exist. Aborting."
    }
    $squirrelPath = Get-Item -Path "$($repoRoot)\packages\*" -Filter "squirrel.windows*"
    if (!(Test-Path "$($squirrelPath)\tools" -PathType Container)) {
        Write-Error "$($squirrelPath)\tools is not found. Aborting."
    }

    . (Join-Path $PSScriptRoot "build-utils.ps1")

    Get-ChildItem -Path $repoRoot -Filter *.nupkg -ErrorAction SilentlyContinue | Remove-Item -Force | Out-Host 

    $json = Get-Content $versionjson | ConvertFrom-Json
    $nuget = Ensure-NuGet

    $cmdInfo = Exec-Command2 -command $nuget -commandArgs "pack `"$($nuspec)`" -o `"$($repoRoot)`" -Version $($json.MajorMinorPatch) -NonInteractive -BasePath `"$outputPath`"" -forwardExitCode
    Write-Host $cmdInfo[0], $cmdInfo[1]
    if ($cmdInfo[2] -ne 0) {
        Write-Error "NuGet package generation failed. Aborting."
    }

    $nupkg = Get-ChildItem -Path $repoRoot -Filter "Jenkins*.nupkg" | Select -First 1
    if (!(Test-Path $nupkg.FullName -PathType Leaf)) {
        Write-Error "Cannot find NuGet package. Aborting."
    }

    $cmdInfo = Exec-Command2 -command "$($squirrelPath)\tools\Squirrel.exe" -commandArgs "--releasify $($nupkg.FullName) -r=$repoRoot\Releases -i=$repoRoot\JenkinsTray\JenkinsTray.ico"
    Write-Host $cmdInfo[0], $cmdInfo[1]
    if ($cmdInfo[2] -ne 0) {
        Write-Error "Squirrel releasify failed. Aborting."
    }
    Write-Host "Releasified $($nupkg.FullName)."

} catch {
    Write-Error "$($_.Exception.Message)"
    Exit 1
}
