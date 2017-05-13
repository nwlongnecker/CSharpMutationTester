grammar Mutator;

// Parser rules
mutFile : 		command* | EOF ;

command :		source | addSource | removeSource | listSource
				| test | addTest   | removeTest   | listTest
				| use
				| strain
				| mutate
				| report ;

source :		SOURCE COLON fileList ;
test :			TEST COLON fileList ;
use :			USE fileList ;

addSource :		ADD SOURCE fileList ;
removeSource :	REMOVE SOURCE fileList ;
addTest :		ADD TEST fileList ;
removeTest :	REMOVE TEST fileList ;
listSource :	LIST SOURCE ;
listTest :		LIST TEST ;

strain :		STRAIN ID mutate+ END ;

mutate :		MUTATE (mutatable TO mutatable | idList) ;
mutatable :		symbolList | fileList | idList ;

report :		REPORT (LAST | ALL)? ((SURVIVED | KILLED | STILLBORN) | fileList)?;

idList :		ID (COMMA ID)* ;
symbolList :	SYMBOL (COMMA SYMBOL)* ;
fileList :		(FILEGLOB) (COMMA (FILEGLOB))* ;

/* Lexical rules */

// Separators and operators
COMMA :			',' ;
COLON :			':' ;

// Reserved words
SOURCE :		'source' ;
TEST :			'test' ;
USE :			'use' ;
ADD :			'add' ;
REMOVE :		'remove' ;
LIST :			'list' ;
STRAIN :		'strain' ;
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

// Will probably change, should at least be able to match +, -, &&, ||, etc.
// Language could/should be expanded to allow other types of mutations
SYMBOL :		(~[ \t\r\n#,:'"])+ |
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
				FILEGLOBCHAR (FILEGLOBCHAR | SPACE)* FILEGLOBCHAR ;
fragment
FILEGLOBCHAR :	LETTER | DIGIT | UNDERSCORE | DOT | STAR | QUESTION ;

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
LETTER :		[A-Za-z] ;

fragment
DIGIT :			[0-9] ;
