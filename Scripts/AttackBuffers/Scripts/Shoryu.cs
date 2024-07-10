


partial class Shoryu : GlobalInputBuffer {
    //////////*Fields*//////////
    const string _animation = "Shoryu";

    readonly string[] _motions = ["Right", "Down", "Right"];
    readonly string[] _forbiddenActions = [];

    const string _button = "Test";

    //////////*Properties*//////////
    private protected override string Animation { get { return _animation; } }

    private protected override string[] Motions { get { return _motions; } }
    private protected override string[] ForbiddenActions { get { return _forbiddenActions; } }

    private protected override string Button { get { return _button; } }

}