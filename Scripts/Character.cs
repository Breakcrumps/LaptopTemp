using Godot;
using static Godot.Input;
using System.Collections.Generic;
using System.Linq;

abstract partial class Character : CharacterBody2D {
    //////////////////////////////
    //////////!Abstract!//////////
    //////////////////////////////

    //////////*Properties*//////////
    private protected abstract int Fws { get; }
    private protected abstract int Bws { get; }
    private protected abstract int Gravity { get; }

    private protected abstract AnimationPlayer Player { get; }

    [Export]
    internal bool CanMove { get; set; }


    //////////////////////////////
    //////////!Concrete!//////////
    //////////////////////////////
    
    //////////*Fields*//////////
    readonly List<string> animations = [];

    //////////*Methods*//////////
    public override void _Ready() {
        CanMove = true;
        foreach (GlobalInputBuffer n in GetNode<Node>("AttackBuffers").GetChildren().Cast<GlobalInputBuffer>())
            n.CharacterPlay += (anim) => { Player.Play(anim); CanMove = false; };
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
        Velocity = velocity;
        MoveAndSlide(); }
}