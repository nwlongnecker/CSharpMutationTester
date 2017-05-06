<#
 .SYNOPSIS
	Generates the Lexer and Parser given an antlr grammar 
 .DESCRIPTION
	Uses the antlr jar to generate the Lexer and Parser
 .PARAMETER GrammarFile
	The grammar file to use to generate the Lexer and Parser
 #>

param([Parameter(Mandatory=$false)][string] $GrammarFile = "Mutator.g4")

# Assume this script is one level below the solution root
$SolutionRoot = (Split-Path (Split-Path -Path $MyInvocation.MyCommand.Path -Parent) -Parent)

$LexerParserProjectPath = Join-Path $SolutionRoot "src/LexerParser"
$OutputDir = Join-Path $LexerParserProjectPath "generated"
$GrammarPath = Join-Path $LexerParserProjectPath (Join-Path "grammars" $GrammarFile)

$JarPath = Join-Path $SolutionRoot "dependencies\antlr-4.7-complete.jar"

"Generating Lexer and Parser from $GrammarPath in $OutputDir directory"
java -jar $JarPath -Dlanguage=CSharp -Werror -visitor -no-listener -o $OutputDir $GrammarPath
