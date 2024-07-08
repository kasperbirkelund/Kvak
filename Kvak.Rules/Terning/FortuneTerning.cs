using Kvak.Rules.Chips;

namespace Kvak.Rules.Terning;

public class FortuneTerning : ITerning
{
    private static readonly ITerningResult[] DiceSides =
    {
       new DraabeResult(),
       new GraeskarResult(),
       new RubinResult(),
       new SejrsPointsResult(1),
       new SejrsPointsResult(1),
       new SejrsPointsResult(2),
    };

    public ITerningResult Roll()
    {
        int rollIndex = Random.Shared.Next(DiceSides.Length);
        return DiceSides[rollIndex];
    }

    internal class SejrsPointsResult : ITerningResult
    {
        private readonly int _antal;

        public SejrsPointsResult(int antal)
        {
            _antal = antal;
        }

        public void Handle(ISpiller spiller)
        {
            spiller.TildelSejrsPoints(_antal);
        }
    }

    internal class DraabeResult : ITerningResult
    {
        public void Handle(ISpiller spiller)
        {
            spiller.Gryde.FlytDraabe(1);
        }
    }

    internal class RubinResult : ITerningResult
    {
        public void Handle(ISpiller spiller)
        {
            spiller.TildelRubiner(1);
        }
    }

    internal class GraeskarResult : ITerningResult
    {
        public void Handle(ISpiller spiller)
        {
            spiller.Pose.Add(new Chip(ChipFarve.Orange, 1));
        }
    }
}