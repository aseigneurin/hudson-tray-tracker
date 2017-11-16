Set-StrictMode -version 2.0
$ErrorActionPreference="Stop"

try {
    . (Join-Path $PSScriptRoot "build-utils.ps1")

    Write-Host "Installing GitVersion.CommandLine"
    $gitversion = Ensure-GitVersion
    Write-Host "Using GitVersion.CommandLine from: $($gitversion.FullName)"
    
    exit 0
}
catch [exception] {
    Write-Host $_.Exception
    exit 1
}
