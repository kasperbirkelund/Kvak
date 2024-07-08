namespace Kvak.Rules.Runder;

public class Runde4 : RundeBase
{
    public Runde4(ISpil spil) : base(spil)
    {
    }

    public override IRunde GetNextRunde(ISpil spil)
    {
        return new Runde5(spil);
    }
}