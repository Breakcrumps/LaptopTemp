using Godot;

partial class Job : Character {
    //////////*Fields*//////////
    const int _fws = 220;
    const int _bws = 200;
    int _health = 100;
    const int _gravity = 10;
    const int _jumpDuration = 38;

    //////////*Properties*//////////
    private protected override int Fws { get { return _fws; } }
    private protected override int Bws { get { return _bws; } }
    internal override int Health {
        get { return _health; }
        set { _health = value; } }
    private protected override int Gravity { get { return _gravity; } }
    private protected override int JumpDuration { get { return _jumpDuration; } }

    private protected override AnimationPlayer Player { get { return GetNode<AnimationPlayer>("JobPlayer"); } }
}
