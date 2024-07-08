using Kvak.Rules.Chips;

namespace Kvak.Rules.Boeger;

public class GroenBog1 : IBogWithEndOfRoundEffect
{
    public int ApplyEffect(IChip chip, ISpiller spiller)
    {
        return chip.Vaerdi;
    }

    public void ApplyDelayedEffect(ISpil spil, ISpiller spiller)
    {
        var trukneChips = spiller.Gryde.GetPlaceredeChips(_ => true).ToList();
        int antalRubiner = 0;

        if (trukneChips.Count > 0 && trukneChips[^1].Farve == ChipFarve.Groen)
        {
            antalRubiner++;
        }

        if (trukneChips.Count > 1 && trukneChips[^2].Farve == ChipFarve.Groen)
        {
            antalRubiner++;
        }

        spiller.TildelRubiner(antalRubiner);
    }
}