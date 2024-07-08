namespace Kvak.Rules.Runder;

public class Runde2 : RundeBase
{
    public Runde2(ISpil spil) : base(spil)
    {
    }

    public override IRunde GetNextRunde(ISpil spil)
    {
        return new Runde3(spil);
    }
}