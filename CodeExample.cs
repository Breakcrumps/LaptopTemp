using System.Collections.Generic;

class ChildClass(int neededInt, string neededString) : ParentClass {
	//////////////////////////////
    //////////!Abstract!//////////
    //////////////////////////////
	
    //////////*Properties*//////////
    private protected string NamedString { get; } // PascalCase for properties.

    //////////////////////////////
    //////////!Concrete!//////////
    //////////////////////////////

	//////////*Types*//////////
 	private enum Lvl { One = 1, Two, Three, Four } /* Prioritise one line enums if range of values is short. PascalCase or 
    convenient abbreviations for types.

	//////////*Fields*//////////
  	const int namedField = 0; // Comment numbers as numbers: "This field equals 0" - for readability.
  	const int _namedFieldUnderProperty = 0; /* Underscore only fields under a property.
    This allows to bring all the properties to the end of the file and still see that the field belongs to one, 
    which is good for stats checking as all the fields are at the top of the file,
    and all the "messengers" are at the bottom.*/

	readonly List<int> namedList = []; // Prioritise new shortened collection constructor.
	readonly string[] namedArray = ["", "", ""];
 	
}