#tool nuget:?package=NUnit.ConsoleRunner&version=3.6.1
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Debug");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

using System.Collections.ObjectModel;
using System.Diagnostics;

var solutionFile = "./MutDSL.sln";

var generatedDirs = GetDirectories("./src/*/bin")
                .Concat(GetDirectories("./src/*/obj"))
                .Concat(GetDirectories("./src/*/generated"));

var retrievedDirs = new Collection<DirectoryPath> {
        Directory("dependencies"),
        Directory("tools"),
        Directory("packages")
    };

var antlrDownloadUri = "http://www.antlr.org/download/antlr-4.7-complete.jar";
var dependenciesDirectory = Directory("dependencies");
var antlrFilePath = "./dependencies/antlr-4.7-complete.jar";

var lexerParserProjectDir = "./src/LexerParser";
var lexerParserOutputDir = lexerParserProjectDir + "/generated";
var grammarFile = lexerParserProjectDir + "/grammars/Mutator.g4";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clobber")
    .Description("Remove all files downloaded by retrieve")
    .Does(() =>
{
    CleanDirectories(retrievedDirs);
    DeleteDirectories(retrievedDirs);
});

Task("Clean")
    .Description("Remove all files generated from the source")
    .Does(() =>
{
    CleanDirectories(generatedDirs);
    DeleteDirectories(generatedDirs);
});

Task("Retrieve")
    .Description("Download all dependencies")
    .Does(() =>
{
    NuGetRestore(solutionFile);
    EnsureDirectoryExists(dependenciesDirectory);
    DownloadFile(antlrDownloadUri, antlrFilePath);
});

Task("Generate")
    .Description("Generate the Lexer and Parser using the Antlr jar")
    .IsDependentOn("Retrieve")
    .Does(() =>
{
    // Configure a headless background process to execute the jar in
    var process = new Process();
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.FileName = "java";
    process.StartInfo.Arguments = "-jar " + antlrFilePath + " -Dlanguage=CSharp -Werror -visitor -no-listener -o " + lexerParserOutputDir + " " + grammarFile;
    process.Start();
    // Wait for jar to finish executing
    var output = process.StandardOutput.ReadToEnd();
    process.WaitForExit();
    if (process.ExitCode != 0) {
        Error(output);
    }
    else {
        Information("Generation successful");
    }
});

Task("DirtyBuild")
    .Description("Build the solution without retrieving or generating first. Fast.")
    .Does(() =>
{
    MSBuild(solutionFile, settings =>
      settings.SetConfiguration(configuration));
});

Task("Build")
    .Description("Build the solution")
    .IsDependentOn("Retrieve")
    .IsDependentOn("Generate")
    .IsDependentOn("DirtyBuild");

Task("Rebuild")
    .Description("Clean, then build the solution")
    .IsDependentOn("Clean")
    .IsDependentOn("Retrieve")
    .IsDependentOn("Generate")
    .IsDependentOn("Build");

Task("DirtyTest")
    .Description("Run tests without regenerating code. Fast.")
    .IsDependentOn("DirtyBuild")
    .Does(() =>
{
    NUnit3("./src/**/bin/" + configuration + "/*.Tests.dll", new NUnit3Settings {
            NoResults = true
        });
});

Task("Test")
    .Description("Run all tests from the solution")
    .IsDependentOn("Build")
    .IsDependentOn("DirtyTest");

Task("CleanTest")
    .Description("Rebuild, then run all tests")
    .IsDependentOn("Rebuild")
    .IsDependentOn("Test");

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
