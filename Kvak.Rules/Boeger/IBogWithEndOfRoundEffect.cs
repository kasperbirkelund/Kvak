namespace Kvak.Rules.Boeger;

public interface IBogWithEndOfRoundEffect : IBog
{
    void ApplyDelayedEffect(ISpil spil, ISpiller spiller);
}