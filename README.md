A small C# Godot v4.3.beta2 project that helps me learn all the things needed to create a fighter.

Code Remarks:

Use tabs.
Make access modifiers as private as possible, unless required to elevate access.
Never use access modifiers above `internal`.
All fields are private.
Never write `private`, unless it matters.
Most of collections are `readonly`, most of valuable fields are `const`.
All classes are private.
Try to use `using static` every time you have to reference a system class - this helps to assert what you need in this file faster and debloats the code.

Code format [here](CodeExample.cs)
