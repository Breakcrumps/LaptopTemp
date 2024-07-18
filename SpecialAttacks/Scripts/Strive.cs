

partial class Strive : SpecialAttack {
    //////////*Properties*//////////
    private protected override int MaxBuffer => 20;
    
    private protected override string Animation => "Strive";

    private protected override int[] Motions => [2, 12, 10, 11, 1, 2];
    private protected override string Button => "Test"; }