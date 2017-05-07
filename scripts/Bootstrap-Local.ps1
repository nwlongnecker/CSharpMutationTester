<#
  .SYNOPSIS
    Configures a local environment for working with the MutDSL project
  .DESCRIPTION
    Installs Chocolatey, NuGet, Java, Cake, then retrieves dependencies and builds the project.
 #>

$ErrorActionPreference = "Stop"

# Assume this script is one level below the solution root
$solutionRoot = (Split-Path (Split-Path -Path $MyInvocation.MyCommand.Path -Parent) -Parent)

# Install Chocolatey
iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

# Install dependencies required by project
choco install nuget.commandline
choco install javaruntime
choco install cake.portable

# Make Cake sane to use
$aliasCake = Join-Path $solutionRoot (Join-Path "scripts" "Alias-Cake.ps1")
. $aliasCake

# Build the project
ck cleantest
