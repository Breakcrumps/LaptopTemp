

partial class Hadou : SpecialAttack {
    //////////*Fields*//////////
    const string _animation = "Hadou";

    readonly string[] _motions = ["Down", "Right"];
    readonly string[] _forbiddenActions = ["Right", "Left"];

    const string _button = "Test";

    //////////*Properties*//////////

    private protected override string Animation { get { return _animation; } }

    private protected override string[] Motions { get { return _motions; } }
    private protected override string[] ForbiddenActions { get { return _forbiddenActions; } }

    private protected override string Button { get { return _button; } }
}