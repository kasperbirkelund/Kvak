using Kvak.Rules.Boeger;
using Kvak.Rules.Chips;

namespace Kvak.Rules.RundeSteps;

public class ApplyLillaStep : IRundeStep
{
    private readonly ISpil _spil;

    public ApplyLillaStep(ISpil spil)
    {
        _spil = spil;
    }

    public void Execute()
    {
        IBogWithEndOfRoundEffect bog = _spil.Boeger.GetDelayedBog(DelayedChipFarve.Lilla);

        foreach (ISpiller spiller in _spil.Spillere)
        {
            bog.ApplyDelayedEffect(_spil, spiller);
        }
    }
}