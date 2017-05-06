# MutDSL

A C# port of my Java-based mutation testing DSL. Supports both REPL mode and script mode.

## Getting started
Instructions for getting the solution set up on your local machine.

### Dependencies
* [NuGet](https://www.nuget.org) command line utility (Or Visual Studio Package Manager)
	* NuGet command line utility is easy to install via [Chocolatey](https://chocolatey.org/install)
	* Install Chocolatey: `iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))`
	* Install NuGet command line: `choco install nuget.commandline`
* [Java](https://java.com/download) needs to be installed and on your path.

### Setup
1. Clone this repo: `git clone https://github.com/nwlongnecker/CSharpMutationTester.git`
2. From the root of the repo, run `./scripts/Generate-LexerParser.ps1` to generate the lexer and parser for interpreting the grammar.
