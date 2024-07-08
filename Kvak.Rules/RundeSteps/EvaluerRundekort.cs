namespace Kvak.Rules.RundeSteps;

public class EvaluerRundekort : IRundeStep
{
    private readonly ISpil _spil;

    public EvaluerRundekort(ISpil spil)
    {
        _spil = spil;
    }

    public void Execute()
    {
        //_spil.CurrentRunde.CurrentRundekort.
    }
}