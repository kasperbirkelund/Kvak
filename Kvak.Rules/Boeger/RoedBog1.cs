using Kvak.Rules.Chips;

namespace Kvak.Rules.Boeger;

public class RoedBog1 : IBog
{
    public int ApplyEffect(IChip chip, ISpiller spiller)
    {
        int countOrange = spiller.Gryde.GetPlaceredeChips(x => x.Farve == ChipFarve.Orange).Count();
        return countOrange switch
        {
            0 => chip.Vaerdi,
            >= 1 and <= 2 => chip.Vaerdi + 1,
            _ => chip.Vaerdi + 2
        };
    }
}