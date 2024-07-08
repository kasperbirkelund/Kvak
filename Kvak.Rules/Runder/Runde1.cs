namespace Kvak.Rules.Runder;

public class Runde1 : RundeBase
{
    public Runde1(ISpil spil) : base(spil)
    {
    }

    public override IRunde GetNextRunde(ISpil spil)
    {
        return new Runde2(spil);
    }
}