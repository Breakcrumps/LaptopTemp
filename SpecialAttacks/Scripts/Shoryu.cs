

partial class Shoryu : SpecialAttack {
    //////////*Fields*//////////
    const string _animation = "Shoryu";

    readonly string[] _motions = ["Right", "Down", "Right"];
    readonly string[] _forbiddenActions = [];

    const string _button = "Test";

    //////////*Properties*//////////
    
    private protected override string Animation => _animation;

    private protected override string[] Motions => _motions;
    private protected override string[] ForbiddenActions => _forbiddenActions;

    private protected override string Button => _button;

}