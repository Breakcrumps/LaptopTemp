

partial class Tatsu : SpecialAttack {
    //////////*Fields*//////////
    const string _animation = "BackHadou";

    readonly string[] _motions = ["Down", "Left"];
    readonly string[] _forbiddenActions = [];

    const string _button = "Test";

    //////////*Properties*//////////

    private protected override string Animation { get { return _animation; } }

    private protected override string[] Motions { get { return _motions; } }
    private protected override string[] ForbiddenActions { get { return _forbiddenActions; } }

    private protected override string Button { get { return _button; } }

}