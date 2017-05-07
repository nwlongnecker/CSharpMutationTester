# MutDSL

A C# port of my Java-based mutation testing DSL. Supports both REPL (Read-Eval-Print Loop) mode and script mode.

## Getting started
Instructions for getting the solution set up on your local machine.

### Setup
Setup is completely scripted. **The setup process will install Chocolatey, NuGet, Java, and Cake on your machine.**
1. Clone this repo: `git clone https://github.com/nwlongnecker/CSharpMutationTester.git`
2. Open a powershell window as administrator and from the root of the repo run `./scripts/Bootstrap-Local.ps1`. You will need to confirm that you would like to install NuGet and Java if they are not already installed. The script will download all dependencies, generate necessary files, build the project, and run the tests.

**Note:** The cake build utility is not simple to use via the commandline. Most cake solutions recommend creating a bootstrap powershell file that you use to simplify calling the cake interpreter. I didn't particularly like that solution, so instead I created an alias script that creates a simpler cli for cake under the alias `ck`.

Standard cake would require you to type `cake build.cake -target=build` to run the build task in the cakefile.

With the alias script, you can just type `ck build` to run the build task. Use `ck help` to see a list of commands.

If you wish to use the `ck` alias, you will need dot source the `Alias-Cake` script to set up the alias each time you open a new powershell window: `. .\scripts\Alias-Cake.ps1`. Alternatively, you could add it to your Powershell Profile so it runs every time without you needing to explicitly call it.

### Trying it out
If you're using the `Alias-Cake` script, the mut .exe has already been aliased to `mut` for you. If not, you can use the longer path: `.\src\Mut\bin\Debug\Mut.exe`.

If you call `mut` with no arguments, it will enter REPL mode. If you call `mut` and pass in the path to a script, it will execute that script, then exit.
