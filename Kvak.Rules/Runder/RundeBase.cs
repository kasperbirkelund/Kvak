using Kvak.Rules.Rundekort;
using Kvak.Rules.RundeSteps;

namespace Kvak.Rules.Runder;

public abstract class RundeBase : IRunde
{
    private readonly ISpil _spil;
    
    protected RundeBase(ISpil spil)
    {
        _spil = spil;
        CurrentRundekort = spil.Rundekort.Dequeue();
    }

    public IRundekort CurrentRundekort { get; }
    public abstract IRunde GetNextRunde(ISpil spil);
    public virtual bool HasMoreRounds => true;

    public virtual IEnumerable<IRundeStep> GetSteps()
    {
        foreach (var step in PreroundSteps(_spil))
        {
            yield return step;
        }
        yield return new TraekBrikkerStep(_spil);
        yield return new EleksirStep();
        yield return new TerningKastStep(_spil);
        yield return new ApplySortStep(_spil);
        yield return new ApplyLillaStep(_spil);
        yield return new ApplyGroenStep(_spil);
        yield return new ApplyRubinStep(_spil);
        yield return new ApplySejsPointsStep(_spil);
        yield return new ApplyKoedBrikkerStep(_spil);
        foreach (var step in PostroundSteps(_spil))
        {
            yield return step;
        }
    }

    protected virtual IEnumerable<IRundeStep> PreroundSteps(ISpil spil)
    {
        yield return new BeregnRottehaler(spil);
    }

    protected virtual IEnumerable<IRundeStep> PostroundSteps(ISpil spil)
    {
        yield return new EvaluerRundekort(spil);
        yield return new KlargoerNaesteRunde(spil);
    }
}