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
 	private enum Lvl { One = 1, Two, Three, Four } /* Prioritise one line enums if ->
    range of values is short. PascalCase or convenient abbreviations for types. */

	//////////*Fields*//////////
  	const int namedField = 0; // camelCase for fields.
    // Comment numbers as numbers: "This field equals 0" - for readability.
  	const int _namedFieldUnderProperty = 0; // Only underscore fields under a property.
    //! When using fields under properties try to name them the same: _health -> Health.

	readonly List<string> namedList = []; // Prioritise new shortened collection constructor.
    readonly List<List<int>> namedListList = [];
    // Always type shit. Helps to guess what you had in mind.
	readonly string[] namedArray = ["", "", ""];
 	
    //////////*Properties*//////////
    [Export] 
    int ExportInt { get; set; } // Leave property attributes above them.
    [Export] 
    Lvl ExportLvl { get; set; } // Also exports at the top of properties.

    int CalculatedValue => namedField * 2 + 1;
    // Follow conventions on mathematical operations. Use => to realise one line get-s and set-s.

    AnimationPlayer Player => (AnimationPlayer)GetChildren().Where(x => x is AnimationPlayer).Single();
    // Prioritise unnamed calls when working with nodes. 
    // AND YES, this is rather fucked. What am I to do?

    //////////*Delegates*//////////
    [Signal]
    internal delegate void FunnyDelegateEventHandler(string delegateString);
    // Doncha forget EventHandler suffix for Godot signals.

    //////////*Methods*//////////
    public override void _Ready() { // I *HATE* Intellisense. Only mark system overrides as public. Watch the braces.
        FunnyDelegate += DoStuff;
        BodyEntered += YameteKudasai;
        Renamed += () => WriteLine($"namedList equals {namedList}"); // Interpolate.
        // Lambda when delegate assigned expression is short
        namedList.AddRange(Player.GetAnimationList()); /* Use Where(), AddRange(),
        GetRange(), ForEach(), Any(), All(), etc. */
        WriteLine("I come"); } // Why did I do that? Space and Python. I'm crazy like that.
    //! Use braces like these everywhere except classes - if-s, switch-es and loops included...
    // ...(but try to make loops with one line techniques.)
    
    void DoStuff(string str) {
        bool[] bools = new bool[3].Where(x => x == false).ToArray();
        /* May initialise collections with new, but only when required. */
        //!Also TYPE EVERYTHING I'M NOT JOKING I'LL DO SOMETHING IF I SEE VAR ANYWHERE. 
        WriteLine(bools.Where(x => x)); }

    void YameteKudasai(Node2D body) { // When realising system events follow parameter patterns exactly...
        Character c = (Character)body;  /* ...and cast with a variable. */ }
}