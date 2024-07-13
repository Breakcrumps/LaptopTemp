A small C# Godot v4.3.beta2 project that helps me learn all the things needed to create a fighter.

Code Remarks:

Use tabs.
Make access modifiers as private as possible, unless required to elevate access.
Never use access modifiers above `internal`, unless overriding system members.
All fields are private.
Never type `private`, unless it matters.
Most of collections are readonly, most of valuable fields are const.
Prioritise empty collections over null.
Try to use `using static` every time you have to reference a system class - this helps to assert what you need in this file faster and debloats the code.
Leave two empty lines at the top of the file when not using libraries.
Never use `var`, always explicitely type code even when using constructors or creating a variable containing explicit casts.
Prioritise use of abstract classes over interfaces; because I'm stupid.
It is OK to make every class partial as we never know how we might need it to interact with Godot.
Don't specify types in member names, except interfaces: `IPascalCase`.
When using fields under properties try to name them the same: `_health` -> `Health`.
Prioritise LINQ and other one line techniques as I've tested them to be equally or more performant in most appropriate contexts.
When confronted with choice to place or not to place curly brackets, don't.
Prioritise `for` for `List` and `foreach` for `Array`.
Prioritise system instruments over the Godot ones.


Code format: [here](CodeExample.cs)
