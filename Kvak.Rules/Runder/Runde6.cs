namespace Kvak.Rules.Runder;

public class Runde6 : RundeBase
{
    public Runde6(ISpil spil) : base(spil)
    {
    }

    public override IRunde GetNextRunde(ISpil spil)
    {
        return new Runde7(spil);
    }
}