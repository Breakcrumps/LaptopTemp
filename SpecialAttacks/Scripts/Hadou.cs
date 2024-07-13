

partial class Hadou : SpecialAttack {
    //////////*Fields*//////////
    const string _animation = "Hadou";

    readonly string[] _motions = ["Down", "Right"];
    readonly string[] _forbiddenActions = ["Right", "Left"];

    const string _button = "Test";

    //////////*Properties*//////////

    private protected override string Animation =>  _animation;

    private protected override string[] Motions => _motions;
    private protected override string[] ForbiddenActions => _forbiddenActions;

    private protected override string Button => _button;
}