using Godot;
using static Godot.Input;
using System.Collections.Generic;
using System.Linq;

abstract partial class Character : CharacterBody2D {
    //////////////////////////////
    //////////!Concrete!//////////
    //////////////////////////////
    
    //////////*Fields*//////////
    readonly List<string> animations = [];

    //////////*Properties*//////////
    [Export]
    int Fws { get; set; }
    [Export]
    int Bws { get; set; }
    [Export]
    internal int Health { get; set; }
    [Export]
    int Gravity { get; set; }
    [Export]
    int JumpDuration { get; set; }

    [Export]
    bool CanMove { get; set; }

    AnimationPlayer Player => (AnimationPlayer)GetChildren().Where(x => x is AnimationPlayer).Single();
    // Yes, this is fucked. Welcome to fucking C#.
    
    int VertSpeed => -JumpDuration/2*Gravity;

    //////////*Methods*//////////
    public override void _Ready() {
        CanMove = true;
        foreach (SpecialAttack special in GetNode<Node2D>("SpecialAttacks").GetChildren().Cast<SpecialAttack>())
            special.CharacterPlay += (anim) => { Player.Play(anim); CanMove = false; };
        foreach (NormalAttack normal in GetNode<Node2D>("NormalAttacks").GetChildren().Cast<NormalAttack>())
            normal.CharacterPlay += (anim) => { Player.Play(anim); CanMove = false; };
        animations.AddRange(Player.GetAnimationList()); }

    public override void _PhysicsProcess(double delta) {
        Vector2 velocity = Velocity;
        if (!IsOnFloor()) {
            velocity.Y += Gravity;
            Velocity = velocity;
            MoveAndSlide();
            return; }
        if (!CanMove)  return;
        velocity.X = 0;
        if (IsActionPressed("Left") != IsActionPressed("Right")) {
            if (IsActionPressed("Left"))  velocity.X -= Bws;
            if (IsActionPressed("Right"))  velocity.X += Fws; }
        if (IsActionJustPressed("Jump")) {
            velocity.Y = VertSpeed;
            Velocity = velocity;
            MoveAndSlide();
            return; }
        Velocity = velocity;
        if (Velocity != Vector2.Zero)  Player.Play("Walk");
        else  Player.Play("Idle");
        MoveAndSlide(); }
}