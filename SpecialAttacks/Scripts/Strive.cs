

partial class Strive : SpecialAttack {
    //////////*Properties*//////////
    private protected override int MaxBuffer => 20;
    
    private protected override string Animation => "Strive";

    private protected override string[] Motions => ["Right", "Down", "Left", "Right"];
    private protected override string Button => "Test"; }