using System.Collections.Generic;
using System.Linq;
using Godot;
using static Godot.Input;

abstract partial class SpecialAttack : Area2D {
    //////////////////////////////
    //////////!Abstract!//////////
    //////////////////////////////

    //////////*Properties*//////////
    private protected abstract string Animation { get; }

    private protected abstract string[] Motions { get; }
    private protected abstract string[] ForbiddenActions { get; }
    private protected abstract string Button { get; }


    //////////////////////////////
    //////////!Concrete!//////////
    //////////////////////////////

    //////////*Types*//////////
    enum Lvl { One = 1, Two, Three, Four }

    //////////*Fields*//////////
    const int maxBuffer = 15;

    readonly string[] actions = ["Left", "Right", "Down"];

    readonly List<List<string>> buffer = [];
    
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
        List<string> frameList = [];
        frameList.AddRange(actions.Where(str => IsActionPressed(str)));
        buffer.Add(frameList);
        if (buffer.Count > maxBuffer)  buffer.RemoveAt(0);
        AttackBuffer(); }
    
    void AttackBuffer() {
        if (!IsActionJustPressed(Button))  return;
        bool[] Flags = new bool[Motions.Length - 1].Where(x => x == false).ToArray();
        int a = 0;
        for (int b = 0; b < buffer.Count; b++) {
            if (a == Motions.Length - 1) {
                if (buffer[b].Contains(Motions[^1]) && !buffer[b].Contains(Motions[^2])) {
                    EmitSignal("CharacterPlay", Animation);
                    return; }
                continue; }
            if (buffer[b].Contains(Motions[a]) && !buffer[b].Contains(Motions[a+1])) {
                if (ForbiddenActions.Any(a => buffer.GetRange(0, b+1).Any(x => x.Contains(a))))
                    return;
                Flags[a] = true;
                a += 1; } } }
        
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