using Kvak.Rules.Terning;

namespace Kvak.Rules.RundeSteps;

public class TerningKastStep : IRundeStep
{
    private readonly ISpil _spil;

    public TerningKastStep(ISpil spil)
    {
        _spil = spil;
    }

    public void Execute()
    {
        var maxGrydefeltValue = _spil.Spillere
            .Where(x => !x.Gryde.ErEksploderet)
            .Max(x => x.Gryde.GetPosition());

        var topPlayers = _spil.Spillere
            .Where(x => !x.Gryde.ErEksploderet && x.Gryde.GetPosition().Equals(maxGrydefeltValue));

        foreach (var player in topPlayers)
        {
            ITerningResult result = _spil.Terning.Roll();
            result.Handle(player);
        }
    }
}