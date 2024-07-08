namespace Kvak.Rules.Runder;

public class Runde8 : RundeBase
{
    public Runde8(ISpil spil) : base(spil)
    {
    }

    public override IRunde GetNextRunde(ISpil spil)
    {
        return new Runde9(spil);
    }
}