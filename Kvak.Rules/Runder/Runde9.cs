using Kvak.Rules.RundeSteps;

namespace Kvak.Rules.Runder;

public class Runde9 : RundeBase
{
    public Runde9(ISpil spil) : base(spil)
    {
    }

    public override bool HasMoreRounds => false;

    public override IRunde GetNextRunde(ISpil spil)
    {
        throw new NotSupportedException("END OF GAME");
    }

    protected override IEnumerable<IRundeStep> PostroundSteps(ISpil spil)
    {
        //Tæl point sammen
        return base.PostroundSteps(spil);
    }
}