using Kvak.Rules.Chips;

namespace Kvak.Rules.Boeger;

public class LillaBog1 : IBogWithEndOfRoundEffect
{
    public int ApplyEffect(IChip chip, ISpiller spiller)
    {
        return 1;
    }

    public void ApplyDelayedEffect(ISpil spil, ISpiller spiller)
    {
        int countLilla = spiller.Gryde.GetPlaceredeChips(x => x.Farve == ChipFarve.Lilla).Count();
        switch (countLilla)
        {
            case 0:
            {
                break;
            }
            case 1:
            {
                spiller.TildelSejrsPoints(1);
                break;
            }
            case 2:
            {
                spiller.TildelSejrsPoints(1);
                spiller.TildelRubiner(1);
                    break;
            }
            default:
            {
                spiller.TildelSejrsPoints(2);
                spiller.Gryde.FlytDraabe(1);
                break;
            }
        }
    }
}