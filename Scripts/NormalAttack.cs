using System.Linq;
using Godot;
using static Godot.Input;

abstract partial class NormalAttack : Area2D {
    //////////////////////////////
    //////////!Abstract!//////////
    //////////////////////////////
    
    //////////*Properties*//////////
    private protected abstract string Animation { get; }   
    private protected abstract string Button { get; }



    //////////////////////////////
    //////////!Concrete!//////////
    //////////////////////////////
    
    //////////*Types*//////////
    enum Lvl { One = 1, Two, Three, Four }

    //////////*Properties*//////////
    [Export]
    int Damage { get; set; }
    [Export]
    int Block { get; set; }
    [Export]
    Lvl Level { get; set; }

    CollisionShape2D Hitbox => (CollisionShape2D)GetChildren().Where(x => x is CollisionShape2D).Single();

    //////////*Delegates*//////////
    [Signal]
    internal delegate void CharacterPlayEventHandler(string anim);

    //////////*Methods*//////////
    public override void _Ready() {
        BodyEntered += DealDamage;
        Hitbox.Disabled = true; }
    
    public override void _PhysicsProcess(double delta) {
        if (IsActionJustPressed(Button))
            EmitSignal("CharacterPlay", Animation); }
    
    void DealDamage(Node2D body) {
        Character b = (Character)body;
        Hitbox.Disabled = true;
        switch (IsActionPressed("Right")) {
            case true:
                b.Health -= Damage;
                goto default;
            case false:
                b.Health -= Block;
                goto default;
            default:
                if (b.Health <= 0)  b.QueueFree();
                break; } }
}