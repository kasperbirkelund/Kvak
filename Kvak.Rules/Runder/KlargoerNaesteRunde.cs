using Kvak.Rules.RundeSteps;

namespace Kvak.Rules.Runder;

public class KlargoerNaesteRunde : IRundeStep
{
    private readonly ISpil _spil;

    public KlargoerNaesteRunde(ISpil spil)
    {
        _spil = spil;
    }

    public void Execute()
    {
        foreach (var spiller in _spil.Spillere)
        {
            spiller.KlargoerNyRunde();
            spiller.Gryde.KlargoerNyRunde();
        }
    }
}