using System.Collections.Generic;
using Godot;
using static Godot.Input;

abstract partial class SpecialAttack : Area2D { //? Class that handles special attack buffering and execution.
    //////////////////////////////
    //////////!Abstract!//////////
    //////////////////////////////

    //////////*Properties*//////////
    private protected abstract string Animation { get; } // Animation name, to be identical to the one in the player.

    private protected abstract int[] Motions { get; } // Things you want inputted before the button press.
    private protected abstract string Button { get; } // Button itself.


    //////////////////////////////
    //////////!Concrete!//////////
    //////////////////////////////

    //////////*Types*//////////
    enum Lvl { One = 1, Two, Three, Four } // Attack level that holds stun info.

    //////////*Fields*//////////
    readonly List<int> buffer = []; // Da man.
    
    //////////*Properties*//////////
    [Export] 
    int Damage { get; set; }
    [Export] 
    int Block { get; set; }
    [Export] 
    Lvl Level { get; set; }
    //? Use [Export] to export properties to Godot UI.

    private protected virtual int MaxBuffer => 15; // How many frames the buffer lasts.

    CollisionShape2D Hitbox => GetNode<CollisionShape2D>("CollisionShape2D");
    // Fuck.

    static int DirX { get {
        if (IsActionPressed("Left") && !IsActionPressed("Right"))  return 1;
        if (IsActionPressed("Right") && !IsActionPressed("Left"))  return 2;
        return 0; } }
    static int DirY { get {
        if (IsActionPressed("Jump") && !IsActionPressed("Down"))  return 2;
        if (IsActionPressed("Down") && !IsActionPressed("Jump"))  return 1;
        return 0; } }
    /* 21 20 22
       01 00 02
       11 10 12 */

    //////////*Delegates*//////////
    [Signal]
    internal delegate void CharacterPlayEventHandler(string anim);
    // Use Character.Player to play animations.

    //////////*Methods*//////////
    public override void _Ready() {
        BodyEntered += DealDamage;
        Hitbox.Disabled = true; }

    public override void _PhysicsProcess(double delta) {
        buffer.Add(DirY * 10 + DirX);
        if (buffer.Count > MaxBuffer)  buffer.RemoveAt(0);
        AttackBuffer(); }
    
    void AttackBuffer() { //? Dive into the past if the button at the end of special input is pressed.
        if (!IsActionJustPressed(Button))  return;
        var currentActionIndex = 0; // Action index to be increased on successfully found input.
        for (var frame = 0; frame < buffer.Count; frame++) {
            if (buffer[frame] == Motions[currentActionIndex])
                currentActionIndex += 1; // Move on to the next action with the current found...
            if (currentActionIndex == Motions.Length) { // But check if it was the last beforehand.
                EmitSignal("CharacterPlay", Animation);
                return; } } }

    void DealDamage(Node2D body) { //? Realise the BodyEntered signal to deal damage and stun!
        var intruder = (Character)body; // Cast Node2D to character to use class Character members.
        Hitbox.SetDeferred("Disabled", true); // Turn the hitbox off after first collision.
        intruder.Health -= Damage;
        intruder.Player.Play($"Hit{(int)Level}");
        if (intruder.Health <= 0)  intruder.QueueFree(); }
}