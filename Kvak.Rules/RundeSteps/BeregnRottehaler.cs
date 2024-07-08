namespace Kvak.Rules.RundeSteps;

public class BeregnRottehaler : IRundeStep
{
    private readonly ISpil _spil;

    public BeregnRottehaler(ISpil spil)
    {
        _spil = spil;
    }

    public void Execute()
    {
        var result = _spil.RottehalerCalculator.CountRottehaler(_spil.Spillere, _spil.CurrentRunde.CurrentRundekort);
        foreach (var r in result)
        {
            r.Spiller.Gryde.SetRottehaler(r.RottehaleAntal);
        }
    }
}