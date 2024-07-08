namespace Kvak.Rules.Runder;

public class Runde5 : RundeBase
{
    public Runde5(ISpil spil) : base(spil)
    {
    }

    public override IRunde GetNextRunde(ISpil spil)
    {
        return new Runde6(spil);
    }
}