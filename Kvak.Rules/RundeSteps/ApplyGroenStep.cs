using Kvak.Rules.Boeger;
using Kvak.Rules.Chips;

namespace Kvak.Rules.RundeSteps;

public class ApplyGroenStep : IRundeStep
{
    private readonly ISpil _spil;

    public ApplyGroenStep(ISpil spil)
    {
        _spil = spil;
    }

    public void Execute()
    {
        IBogWithEndOfRoundEffect bog = _spil.Boeger.GetDelayedBog(DelayedChipFarve.Groen);

        foreach (ISpiller spiller in _spil.Spillere)
        {
            bog.ApplyDelayedEffect(_spil, spiller);
        }
    }
}