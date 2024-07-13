

partial class Half : SpecialAttack {
    //////////*Fields*//////////
    const string _animation = "Half";

    readonly string[] _motions = ["Left", "Down", "Right"];
    readonly string[] _forbiddenActions = [];

    const string _button = "Test";

    //////////*Properties*//////////
    
    
    private protected override string Animation => _animation;

    private protected override string[] Motions => _motions;
    private protected override string[] ForbiddenActions => _forbiddenActions;

    private protected override string Button => _button;

}