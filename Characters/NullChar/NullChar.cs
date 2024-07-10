using Godot;

partial class NullChar : Character {
    //////////*Fields*//////////
    const int _fws = 220;
    const int _bws = 200;
    const int _gravity = 10;

    //////////*Properties*//////////
    private protected override int Fws { get { return _fws; } }
    private protected override int Bws { get { return _bws; } }
    private protected override int Gravity { get { return _gravity; } }

    private protected override AnimationPlayer Player { get { return GetNode<AnimationPlayer>("NullPlayer"); } }
}
