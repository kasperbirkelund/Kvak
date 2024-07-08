namespace Kvak.Rules.Runder;

public class Runde7 : RundeBase
{
    public Runde7(ISpil spil) : base(spil)
    {
    }

    public override IRunde GetNextRunde(ISpil spil)
    {
        return new Runde8(spil);
    }
}