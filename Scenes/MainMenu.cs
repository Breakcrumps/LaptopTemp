using Godot;

partial class MainMenu : Control {
    Button Start => GetNode<Button>("Start");
    Button Exit => GetNode<Button>("Exit");
    
    public override void _Ready() {
        Start.Pressed += () => GetTree().ChangeSceneToFile("res://Scenes/Scene.tscn");
        Exit.Pressed += () => GetTree().Quit(); }
}