<#
  .SYNOPSIS
    Create an alias to make cake easier to work with
  .DESCRIPTION
    Cake requires you to explicitly pass each of the arguments as named parameters. Less typing.
  .PARAMETER cakeFile
    The cakeFile to use
 #>

param(
    [Parameter(Mandatory=$false)][string] $cakeFile)

# Assume this script is one level below the solution root
$solutionRoot = (Split-Path (Split-Path -Path $MyInvocation.MyCommand.Path -Parent) -Parent)

If(!$cakeFile) {
    $cakeFile = Join-Path $solutionRoot "build.cake"
}

$cakePath = Join-Path $env:ChocolateyInstall "bin\cake.exe"

function callCake($task) {
    If ($task.Equals("help") -or $task.Equals("--help")) {
        & $cakePath "--showdescription"
        return
    }
    $target = If($task) {"-target=$task"} Else {""}
    "Executing $cakePath $cakeFile $target"
    & $cakePath $cakeFile $target
}

Set-Alias ck callCake
Set-Alias mut (Join-Path $solutionRoot "src\Mut\bin\Debug\Mut.exe")
