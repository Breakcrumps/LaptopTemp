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
    private protected abstract int Health { get; set; }
    private protected abstract int Gravity { get; }
    private protected abstract int JumpDuration { get; }

    private protected abstract AnimationPlayer Player { get; }

    [Export]
    internal bool CanMove { get; set; }


    //////////////////////////////
    //////////!Concrete!//////////
    //////////////////////////////
    
    //////////*Fields*//////////
    readonly List<string> animations = [];

    //////////*Properties*//////////
    int VertSpeed { get { return -JumpDuration/2*Gravity; } }

    //////////*Methods*//////////
    public override void _Ready() {
        CanMove = true;
        foreach (SpecialAttack n in GetNode<Node>("AttackBuffers").GetChildren().Cast<SpecialAttack>()) {
            n.CharacterPlay += (anim) => { Player.Play(anim); CanMove = false; };
            n.DealDamage += TakeDamage; }
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
        if (IsActionJustPressed("Jump"))
            velocity.Y = VertSpeed;
        Velocity = velocity;
        MoveAndSlide(); }

    internal void TakeDamage(int damage, int block, int level) {
        switch (IsActionPressed("Right")) {
            case true:
                Health -= damage;
                goto default;
            case false:
                Health -= block;
                goto default;
            default:
                if (Health <= 0)  QueueFree();
                break; } }
}