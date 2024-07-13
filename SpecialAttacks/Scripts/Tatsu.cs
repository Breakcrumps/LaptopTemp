

partial class Tatsu : SpecialAttack {
    //////////*Fields*//////////
    const string _animation = "BackHadou";

    readonly string[] _motions = ["Down", "Left"];
    readonly string[] _forbiddenActions = [];

    const string _button = "Test";

    //////////*Properties*//////////

    private protected override string Animation => _animation;

    private protected override string[] Motions => _motions;
    private protected override string[] ForbiddenActions => _forbiddenActions;

    private protected override string Button => _button;

}