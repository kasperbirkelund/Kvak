using Kvak.Rules.Chips;

namespace Kvak.Rules.Boeger;

public class SortBog1 : IBogWithEndOfRoundEffect
{
    public int ApplyEffect(IChip chip, ISpiller spiller)
    {
        return 1;
    }

    public void ApplyDelayedEffect(ISpil spil, ISpiller spiller)
    {
        var andreSpillere = spil.Spillere.Where(s => s != spiller).ToList();

        if (andreSpillere.Count == 1)
        {
            // Der er kun en anden spiller
            var andenSpiller = andreSpillere[0];

            int playerBlackChips = CountBlackChips(spiller.Gryde);
            int otherPlayerBlackChips = CountBlackChips(andenSpiller.Gryde);

            if (playerBlackChips > otherPlayerBlackChips)
            {
                // Move the drop one space and give one rubin
                spiller.Gryde.FlytDraabe(1);
                spiller.TildelRubiner(1);
            }
            else if (playerBlackChips == otherPlayerBlackChips)
            {
                // Move the drop one space
                spiller.Gryde.FlytDraabe(1);
            }
        }
        else if (andreSpillere.Count > 1)
        {
            // Der er flere end en anden spiller
            int playerBlackChips = CountBlackChips(spiller.Gryde);

            ISpiller rightPlayer = spiller.HøjreSpiller;
            ISpiller leftPlayer = spiller.VenstreSpiller;

            int rightPlayerBlackChips = CountBlackChips(rightPlayer.Gryde);
            int leftPlayerBlackChips = CountBlackChips(leftPlayer.Gryde);

            if (playerBlackChips > rightPlayerBlackChips && playerBlackChips > leftPlayerBlackChips)
            {
                // Move the drop one space and give one rubin
                spiller.Gryde.FlytDraabe(1);
                spiller.TildelRubiner(1);
            }
            else if (playerBlackChips > rightPlayerBlackChips || playerBlackChips > leftPlayerBlackChips)
            {
                // Move the drop one space
                spiller.Gryde.FlytDraabe(1);
            }
        }
    }

    private int CountBlackChips(IGryde gryde)
    {
        return gryde.GetPlaceredeChips(x => x.Farve == ChipFarve.Sort).Count();
    }
}