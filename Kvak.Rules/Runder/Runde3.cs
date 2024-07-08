namespace Kvak.Rules.Runder;

public class Runde3 : RundeBase
{
    public Runde3(ISpil spil) : base(spil)
    {
    }

    public override IRunde GetNextRunde(ISpil spil)
    {
        return new Runde4(spil);
    }
}