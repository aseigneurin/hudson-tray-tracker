<#
.SYNOPSIS
A PowerShell script to package and releasify Jenkins Tray.
#>
[CmdletBinding(PositionalBinding = $false)]
param (
    #[Parameter(Mandatory=$true)]
    [ValidateNotNullOrEmpty()]
    [string]$repoRoot = "$($PSScriptRoot)\..",
    [ValidateNotNullOrEmpty()]
    [string]$versionjson = "$($repoRoot)\version.json",
    [ValidateNotNullOrEmpty()]
    [string]$nuspec = "$($repoRoot)\JenkinsTray.nuspec",
    [ValidateNotNullOrEmpty()]
    [string]$outputPath = "$($repoRoot)\JenkinsTray\bin\x86\Release",
    [parameter(ValueFromRemainingArguments = $true)] $badArgs)

#Requires -Version 3.0

try {
    . (Join-Path $PSScriptRoot "build-utils.ps1")

    $squirrelPath = Get-Item -Path "$($repoRoot)\packages\*" -Filter "squirrel.windows*"
    if (!(Test-Path "$($squirrelPath)\tools" -PathType Container)) {
        Write-Error "$($squirrelPath)\tools is not found. Aborting." -ErrorAction Stop
    }

    $json = Get-Content $versionjson | ConvertFrom-Json

    $nuget = Ensure-NuGet
    Exec-Command -command $nuget -commandArgs "pack `"$($nuspec)`" -o `"$($repoRoot)`" -Version $($json.MajorMinorPatch) -NonInteractive -Properties BasePath=$outputPath" | Out-Host

    $nupkg = Get-ChildItem -Path "$($repoRoot)" -Filter "Jenkins.Tray*.nupkg"
    if (!(Test-Path $nupkg -PathType Leaf)) {
        Write-Error "Cannot find NuGet package. Aborting." -ErrorAction Stop
    }

    Exec-Command -command "$($squirrelPath)\tools\Squirrel.exe" -commandArgs "--releasify $($nupkg.FullName)" | Out-Host
    Write-Host "Releasified $($nupkg.FullName)."

} catch {
    Write-Error "$($_.Exception.Message)"
    Exit 1
}
