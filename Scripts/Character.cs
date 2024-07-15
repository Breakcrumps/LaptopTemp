using Godot;
using static Godot.Input;
using System.Linq;
using System.Collections;

abstract partial class Character : CharacterBody2D { //? Class that handles movement and character characteristics.
    //////////////////////////////
    //////////!Concrete!//////////
    //////////////////////////////

    //////////*Properties*//////////
    [Export]
    int Fws { get; set; } // Forward walk speed.
    [Export]
    int Bws { get; set; } // Backward walk speed.
    [Export]
    internal int Health { get; set; } // Internal gives access to attack classes.
    [Export]
    int JumpHeight { get; set; } // Multiplier.
    [Export]
    int JumpDuration { get; set; } // In frames. Fighters default to 60 FPS.
    //? Use [Export] to export properties to Godot UI.

    [Export]
    bool CanMove { get; set; } // Flag that allows actions in _PhysicsUpdate(), mainly movement.

    AnimationPlayer Player => (AnimationPlayer)GetChildren().Where(x => x is AnimationPlayer).First();
    // Yes, this is fucked. Welcome to fucking C#.
    
    int Gravity => JumpHeight;
    int VertSpeed => -JumpDuration/2*JumpHeight;
    // Formula that calculates starting speed and makes the jump controllable.

    static bool Left => IsActionPressed("Left"); // Some performance bull crap.
    static bool Right => IsActionPressed("Right");
    static bool Jump => IsActionPressed("Jump");
    static bool Down => IsActionPressed("Down");

    //////////*Methods*//////////
    public override void _Ready() {
        CanMove = true; // Character can move from birth.
        foreach (SpecialAttack special in GetNode<Node2D>("SpecialAttacks").GetChildren().Cast<SpecialAttack>())
            special.CharacterPlay += (anim) => { if (CanMove) { Player.Play(anim); CanMove = false; } };
        foreach (NormalAttack normal in GetNode<Node2D>("NormalAttacks").GetChildren().Cast<NormalAttack>())
            normal.CharacterPlay += (anim) => { if (CanMove) { Player.Play(anim); CanMove = false; } }; }
        // Two realisations for attack signals that allow attack to ask character to PLayer.Play() needed animation.
            
    public override void _PhysicsProcess(double delta) { //? 60 times a second.
        Vector2 velocity = Velocity; // Point of contention, but Velocity is not obviously Vector2.
        // C# specialty. You branch velocity from Velocity and then merge. Blah-blah info hiding, blah-blah encapsulation.
        if (!IsOnFloor()) { //? Executed when airborne.
            velocity.Y += Gravity; // Apply gravity.
            Velocity = velocity;
            MoveAndSlide(); // Call MoveAndSlide() at the point where Velocity is finalised to move the character.
            return; }
        if (!CanMove)  return; // Don do shit when animating and shit.
        velocity.X = 0; // So that the character does not accelerate to heavens.
        if (Left != Right) {
            if (Left)  velocity.X -= Bws;
            if (Right)  velocity.X += Fws; } // Feels bad.
        if (Jump) {
            velocity.Y = VertSpeed; // Give the character Y momentum.
            Velocity = velocity;
            MoveAndSlide();
            return; }
        Velocity = velocity;
        if (Velocity != Vector2.Zero)  Player.Play("Walk");
        else  Player.Play("Idle");
        MoveAndSlide(); }
}