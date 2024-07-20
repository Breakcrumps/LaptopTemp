using Godot;
using static Godot.Input;

partial class MainMenu : Control {
    Button Start => GetNode<Button>("Start");
    Button Exit => GetNode<Button>("Exit");
    
    public override void _Ready() {
        Start.Pressed += () => GetTree().ChangeSceneToFile("res://Scenes/Scene.tscn");
        Exit.Pressed += () => GetTree().Quit(); }
    
    public override void _PhysicsProcess(double delta) {
        if (IsActionJustPressed("Test"))
            GetTree().ChangeSceneToFile("res://Scenes/Scene.tscn");
        if (IsActionJustPressed("K"))
            GetTree().Quit(); } }