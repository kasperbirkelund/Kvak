using Kvak.Rules.Rundekort;

namespace Kvak.Rules;

public class RottehalerCalculator : IRottehalerCalculator
{
    private static readonly int[] RatTailPositions = { 2, 6, 10, 14, 18, 22, 26, 30, 34, 38, 42, 46, 50 };

    public IEnumerable<Rottehaler> CountRottehaler(IList<ISpiller> spillere, IRundekort currentRundeCurrentRundekort)
    {
        var leadingPlayer = spillere.OrderByDescending(s => s.SejrsPoint).First();
        var rottehalerList = new List<Rottehaler>();

        foreach (var spiller in spillere)
        {
            if (spiller == leadingPlayer)
            {
                rottehalerList.Add(new Rottehaler(spiller, 0));
                continue;
            }

            int rottehalerCount = CalculateRatTails(leadingPlayer.SejrsPoint, spiller.SejrsPoint);
            rottehalerList.Add(new Rottehaler(spiller, rottehalerCount));
        }

        return rottehalerList;
    }

    private int CalculateRatTails(int leadingScore, int trailingScore)
    {
        int ratTails = 0;

        foreach (int position in RatTailPositions)
        {
            if (trailingScore < position && position <= leadingScore)
            {
                ratTails++;
            }
        }

        return ratTails;
    }
}