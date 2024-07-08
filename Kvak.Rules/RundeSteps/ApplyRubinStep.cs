namespace Kvak.Rules.RundeSteps;

public class ApplyRubinStep : IRundeStep
{
    private readonly ISpil _spil;

    public ApplyRubinStep(ISpil spil)
    {
        _spil = spil;
    }

    public void Execute()
    {
        foreach (ISpiller spiller in _spil.Spillere)
        {
            if (spiller.Gryde.GetPosition().ErRubinFelt)
            {
                spiller.TildelRubiner(1);
            }
        }
    }
}