using System.Collections.Generic;
using System.Linq;
using static System.Console; // When using system classes try to static include them.
using Godot;

abstract partial class ChildClass(int neededInt, string neededString) : Area2D { //PascalCase for classes.
// Use primary constructors when possible.
	//////////////////////////////
    //////////!Abstract!//////////
    //////////////////////////////
	
    //////////*Properties*//////////
    private protected abstract string NamedStringForChildren { get; } // PascalCase for properties.

    internal abstract int NamedIntForOtherClasses { get; } // Like Health.


    //////////////////////////////
    //////////!Concrete!//////////
    //////////////////////////////

	//////////*Types*//////////
 	private enum Lvl { One = 1, Two, Three, Four } // PascalCase or convenient abbreviations for types.
    // Prioritise one line enums if the range of values is short.

	//////////*Fields*//////////
  	const int namedField = 0; // camelCase for fields.
    /* Comment numbers as numbers:
    "This field equals 0" - right.
    "This field equals zero" - wrong. */
  	const int _namedFieldUnderProperty = 0; // Only underscore fields under a property.
    //? When using fields under properties try to name them the same: _health -> Health.

	readonly List<string> namedList = []; // Prioritise new shortened collection constructor.
    readonly List<List<int>> namedListList = [];
    // Always type shit. Helps to guess what you had in mind.
	readonly string[] namedArray = ["", "", ""];
 	
    //////////*Properties*//////////
    [Export] 
    int ExportInt { get; set; } // Leave property attributes above them.
    [Export] 
    Lvl ExportLvl { get; set; } // Also exports at the top of *Properties* section.

    int CalculatedValue => namedField * 2 + 1;
    // Follow conventions on mathematical operations. Use => to realise one line get-s and set-s.

    AnimationPlayer Player => (AnimationPlayer)GetChildren().Where(x => x is AnimationPlayer).First();
    // Prioritise unnamed calls when working with nodes. 
    //? AND YES, this is rather fucked. What am I to do?

    //////////*Delegates*//////////
    [Signal]
    internal delegate void FunnyDelegateEventHandler(string delegateString);
    // Doncha forget EventHandler suffix for Godot signals.

    //////////*Methods*//////////
    public override void _Ready() { // I *HATE* Intellisense.
    // Mark only system overrides as public. Watch the braces.
        FunnyDelegate += DoStuff;
        BodyEntered += YameteKudasai;
        Renamed += () => WriteLine($"namedList equals {namedList}"); // Interpolate.
        // Lambda when delegate assigned expression is short.
        namedList.AddRange(Player.GetAnimationList()); /* Use Where(), AddRange(), ->
        GetRange(), ForEach(), Any(), All(), etc. */
        WriteLine("I come"); }
    //? Use braces like these everywhere except classes - if-s, switch-es and loops included...
    // ...(but try to make loops with one line techniques.)
    
    void DoStuff(string str) {
        var bools = new bool[3].Where(x => x == false).ToArray();
        // May initialise collections with new, but only when required.
        // Pay attention: declaration on the right contains verbose type information.
        WriteLine(bools.Where(x => x)); }

    void YameteKudasai(Node2D body) { // When realising system events follow parameter patterns exactly...
        var c = (Character)body;  // ...and cast with a variable.
        /* Variable names can be one-letter or abbreviated. ->
        Just make sure it's easy to follow. */ }
}