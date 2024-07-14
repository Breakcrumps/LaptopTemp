# A small C# Godot v4.3.beta2 project that helps me learn all the things needed to create a fighter.
## Code spec:
- Use 4 spaces.

- Never type access modifiers unless they matter.

- Make access modifiers as private as possible, and elevate access later if necessary.\
Never use access modifiers above `internal`, unless overriding system[^1] members.

- All fields are private.

- Most of the collections are readonly, most of the valuable fields are const.\
Prioritise empty collections over `null`.

- Try to use `using static` every time you have to reference a system class - this helps to assert what this file uses faster and debloats the code.\
Leave two empty lines at the top of the file when not using libraries.

- Only use `var` when absolutely certain it's obvious what the type is and no crazy magic is to insue, for example when using constructors or creating a variable containing explicit casts; read more at [Microsoft C# code conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions).\
Don't specify types in member names, except interfaces: `IPascalCase`.

- Prioritise use of abstract classes over interfaces; because I'm stupid.\
It is OK to make every class partial as we never know how we might need it to interact with Godot.

- When using fields under properties try to name them the same: `_health` -> `Health`.

- Prioritise LINQ and other one line techniques as I've tested them to be equally or more performant in most appropriate contexts.\
Prioritise system instruments over the Godot ones.

- When confronted with choice to place or not to place curly brackets, don't.

- Prioritise `for` for `List` and `foreach` for `Array`.
> [!Important]
> Code example: [here](CodeExample.cs)
[^1]: System - adjective used here to describe members supplied by external libraries.\
In our case - mostly C# `namespace System` and Godot `namespace Godot`.
