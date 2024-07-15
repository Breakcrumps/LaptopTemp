using System.Collections.Generic;
using System.Linq;
using Godot;
using static Godot.Input;

abstract partial class SpecialAttack : Area2D { //? Class that handles special attack buffering and execution.
    //////////////////////////////
    //////////!Abstract!//////////
    //////////////////////////////

    //////////*Properties*//////////
    private protected abstract string Animation { get; } // Animation name, to be identical to the one in the player.

    private protected abstract string[] Motions { get; } // Things you want inputted before the button press...
    private protected abstract string[] ForbiddenActions { get; } // ...and things you don't.
    private protected abstract string Button { get; } // Button itself.


    //////////////////////////////
    //////////!Concrete!//////////
    //////////////////////////////

    //////////*Types*//////////
    enum Lvl { One = 1, Two, Three, Four } // Attack level that holds stun info.

    //////////*Fields*//////////
    const int maxBuffer = 15; // How many frames the buffer lasts.

    readonly string[] actions = ["Left", "Right", "Down"]; // Actions that make it to the buffer.

    readonly List<List<string>> buffer = []; // Da man.
    
    //////////*Properties*//////////
    [Export] 
    int Damage { get; set; }
    [Export] 
    int Block { get; set; }
    [Export] 
    Lvl Level { get; set; }
    //? Use [Export] to export properties to Godot UI.

    CollisionShape2D Hitbox => (CollisionShape2D)GetChildren().Where(x => x is CollisionShape2D).Single();
    // Fuck.

    //////////*Delegates*//////////
    [Signal]
    internal delegate void CharacterPlayEventHandler(string anim);
    // Use Character.Player to play animations.

    //////////*Methods*//////////
    public override void _Ready() {
        BodyEntered += DealDamage;
        Hitbox.Disabled = true; }

    public override void _PhysicsProcess(double delta) {
        List<string> frameList = [];
        frameList.AddRange(actions.Where(str => IsActionPressed(str)));
        // Add inputted items from actions.
        buffer.Add(frameList);
        if (buffer.Count > maxBuffer)  buffer.RemoveAt(0);
        AttackBuffer(); }
    
    void AttackBuffer() { //? Dive into the past if the button at the end of special input is pressed.
        if (!IsActionJustPressed(Button))  return;
        var currentActionIndex = 0; // Action index to be increased on successfully found input.
        for (int frame = 0; frame < buffer.Count; frame++) {
            if (currentActionIndex == Motions.Length - 1) {
                if (buffer[frame].Contains(Motions[^1]) && !buffer[frame].Contains(Motions[^2])) {
                    EmitSignal("CharacterPlay", Animation);
                    return; }
                continue; } // If on the last action, search for the last input without the previous and play!
            if (buffer[frame].Contains(Motions[currentActionIndex]) && !buffer[frame].Contains(Motions[currentActionIndex+1])) {
                if (ForbiddenActions.Any(forbiddenAction =>
                    buffer.GetRange(0, frame+1).Any(frame => frame.Contains(forbiddenAction))))
                    return;
                currentActionIndex += 1; } } } /* Dive into the frame and -> 
            if it contains the needed action without the next one, move to the next action! */
        
    void DealDamage(Node2D body) { //? Realise the BodyEntered signal to deal damage and stun!
        var intruder = (Character)body; // Cast Node2D to character to use class Character members.
        Hitbox.Disabled = true; // Turn the hitbox off after the first collision.
        switch (IsActionPressed("Right")) {
            case true:
                intruder.Health -= Damage;
                goto default;
            case false:
                intruder.Health -= Block;
                goto default;
            default:
                if (intruder.Health <= 0)  intruder.QueueFree();
                break; } } // Check block and die if dead.
}