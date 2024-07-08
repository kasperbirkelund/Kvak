using Kvak.Rules.RundeSteps;

namespace Kvak.Rules.Runder;

public class TraekBrikkerStep : IRundeStep
{
    private readonly ISpil _spil;

    public TraekBrikkerStep(ISpil spil)
    {
        _spil = spil;
    }

    public void Execute()
    {
        foreach (var spiller in _spil.Spillere)
        {
            spiller.TraekBrikker(_spil.Boeger);
        }
    }
}