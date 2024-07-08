namespace Kvak.Rules.RundeSteps;

public class ApplySejsPointsStep : IRundeStep
{
    private readonly ISpil _spil;

    public ApplySejsPointsStep(ISpil spil)
    {
        _spil = spil;
    }

    public void Execute()
    {
        foreach (ISpiller spiller in _spil.Spillere)
        {
            if (spiller.Gryde.ErEksploderet)
            {
                //NO OP - køb i stedet for
            }
            else
            {
                int antalSejsPoint = spiller.Gryde.GetPosition().SejrsPoint;
                spiller.TildelSejrsPoints(antalSejsPoint);
            }
        }
    }
}