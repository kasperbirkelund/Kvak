namespace Kvak.Rules.RundeSteps;

public class ApplyKoedBrikkerStep : IRundeStep
{
    private readonly ISpil _spil;

    public ApplyKoedBrikkerStep(ISpil spil)
    {
        _spil = spil;
    }

    public void Execute()
    {
        //TODO: Implement magic
    }
}