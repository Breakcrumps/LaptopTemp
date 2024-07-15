using System.Linq;
using Godot;
using static Godot.Input;

abstract partial class NormalAttack : Area2D { //? Class that handles normal attack input and execution.
    //////////////////////////////
    //////////!Abstract!//////////
    //////////////////////////////
    
    //////////*Properties*//////////
    private protected abstract string Animation { get; } // Animation name, to be identical to the one in the player.
    private protected abstract string Button { get; } // Button itself.


    //////////////////////////////
    //////////!Concrete!//////////
    //////////////////////////////
    
    //////////*Types*//////////
    enum Lvl { One = 1, Two, Three, Four } // Attack level that holds stun info.

    //////////*Properties*//////////
    [Export]
    int Damage { get; set; }
    [Export]
    int Block { get; set; }
    [Export]
    Lvl Level { get; set; }
    //? Use [Export] to export properties to Godot UI.

    CollisionShape2D Hitbox => (CollisionShape2D)GetChildren().Where(x => x is CollisionShape2D).First();
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
        if (IsActionJustPressed(Button))
            EmitSignal("CharacterPlay", Animation); }
    
    void DealDamage(Node2D body) { //? Realise the BodyEntered signal to deal damage and stun!
        var intruder = (Character)body; // Cast Node2D to character to use class Character members.
        Hitbox.Disabled = true; // Turn the hitbox after first collision.
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