grammar Mutator;

/* Parser rules */
mutFile : 		command* | EOF ;

command :		set
				| use
				| add
				| remove
				| list
				| module
				| mutate
				| report ;

set :			SET (SOURCE | TEST) fileList ;
use :			USE fileList ;

add :			ADD (SOURCE | TEST) fileList ;
remove :		REMOVE (SOURCE | TEST) fileList ;
list :			LIST (SOURCE | TEST) ;

module :		MODULE ID mutate+ END ;

mutate :		MUTATE (mutatable TO mutatable | idList) ;
mutatable :		symbolList | fileList | idList ;

report :		REPORT (LAST | ALL)? ((SURVIVED | KILLED | STILLBORN) | fileList)?;

idList :		ID (COMMA ID)* ;
symbolList :	SYMBOL (COMMA SYMBOL)* ;
fileList :		FILEGLOB (COMMA FILEGLOB)* ;

/* Lexical rules */

// Separators and operators
COMMA :			',' ;

// Reserved words
SOURCE :		'source' ;
TEST :			'test' ;
USE :			'use' ;
ADD :			'add' ;
SET :			'set' ;
REMOVE :		'remove' ;
LIST :			'list' ;
MODULE :		'module' ;
END :			'end' ;
MUTATE :		'mutate' ;
TO :			'to' ;
REPORT :		'report' ;
LAST :			'last' ;
ALL :			'all' ;
SURVIVED :		'survived' ;
KILLED :		'killed' ;
STILLBORN :		'stillborn' ;

// The rest
ID : 			LETTER (LETTER|DIGIT|UNDERSCORE)* ;
// Match any file or directory name, with or without quotes and allowing spaces
// Matches a glob of files accepting * or ? as wildcard characters
FILEGLOB :		FILEGLOBBASE |
				QUOTE FILEGLOBWSBASE QUOTE |
				DOUBLEQUOTE FILEGLOBWSBASE DOUBLEQUOTE ;

// Match anything from symbol like && or >= to a full regex
SYMBOL :		(~[ \t\r\n#,'"])+ |
				QUOTE (~['])* QUOTE |
				DOUBLEQUOTE (~["])* DOUBLEQUOTE ;

WHITESPACE :	([ \t\r\n] | COMMENT)+ -> skip ;
COMMENT :		'#' .*? ('\n'|EOF) ;

fragment
FILEGLOBBASE :	(FILEGLOBCHAR+ SLASH)* FILEGLOBCHAR+ SLASH? ;
fragment
FILEGLOBWSBASE:	(DIRNAMEWS SLASH)* DIRNAMEWS SLASH? ;
fragment
DIRNAMEWS :		FILEGLOBCHAR |
				FILEGLOBCHAR (FILEGLOBCHAR | SPACE | DASH)* FILEGLOBCHAR ;
fragment
FILEGLOBCHAR :	LETTER | DIGIT | UNDERSCORE | DOT | STAR | QUESTION | COLON ;

fragment
UNDERSCORE :	'_' ;
fragment
DOT :			'.' ;
fragment
SLASH :			'/' | '\\' ;
fragment
STAR :			'*' ;
fragment
QUOTE :			'\'' ;
fragment
DOUBLEQUOTE :	'"' ;
fragment
SPACE :			' ' ;
fragment
QUESTION :		'?' ;
fragment
COLON :			':' ;
fragment
DASH :			'\u002D' ;

fragment
LETTER :		[A-Za-z] ;

fragment
DIGIT :			[0-9] ;
