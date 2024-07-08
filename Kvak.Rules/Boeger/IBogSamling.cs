using Kvak.Rules.Chips;

namespace Kvak.Rules.Boeger;

public interface IBogSamling
{
    IDictionary<ChipFarve, IBog> Boeger { get; }
    IBog GetBog(ChipFarve chipFarve);
    IBogWithEndOfRoundEffect GetDelayedBog(DelayedChipFarve chipFarve)
    {
        ChipFarve farve = ChipFarve.Groen;
        if (chipFarve == DelayedChipFarve.Groen)
        {
            farve = ChipFarve.Groen;
        }
        else if(chipFarve == DelayedChipFarve.Sort)
        {
            farve = ChipFarve.Sort;
        }
        else if (chipFarve == DelayedChipFarve.Lilla)
        {
            farve = ChipFarve.Lilla;
        }
        return (IBogWithEndOfRoundEffect)GetBog(farve);
    }
}