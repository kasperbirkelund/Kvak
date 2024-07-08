using Kvak.Rules;
using Kvak.Rules.Boeger;
using Kvak.Rules.Chips;
using Kvak.Rules.Rundekort;

namespace Kvak.Cmd;

internal class Program
{
    static void Main(string[] args)
    {
        Queue<IRundekort> rundekort = new Queue<IRundekort>(new[]
        {
            new NullRundekort(),
            new NullRundekort(),
            new NullRundekort(),
            new NullRundekort(),
            new NullRundekort(),
            new NullRundekort(),
            new NullRundekort(),
            new NullRundekort(),
            new NullRundekort(),
            new NullRundekort(),
        });
        IBogSamling boeger = new BogSamling(new Dictionary<ChipFarve, IBog>
        {
            { ChipFarve.Gul, new NullBog(ChipFarve.Gul) },
            { ChipFarve.Groen, new GroenBog1() },
            { ChipFarve.Sort, new SortBog1() },
            { ChipFarve.Lilla, new LillaBog1() },
            { ChipFarve.Roed, new RoedBog1() },
            { ChipFarve.Blomst, new NullBog(ChipFarve.Blomst) },
            { ChipFarve.Orange, new NullBog(ChipFarve.Orange) },
            { ChipFarve.Blaa, new NullBog(ChipFarve.Blaa) }
        });
        IList<ISpiller> spillere = new List<ISpiller>
        {
            new Spiller(null, SpillerFarve.Blaa),
            new Spiller(null, SpillerFarve.Groen),
            new Spiller(null, SpillerFarve.Roed),
            new Spiller(null, SpillerFarve.Sort),
            new Spiller(null, SpillerFarve.Gul),
        };
        ISpil spil = new Spil(boeger, spillere, null, rundekort);
        IEnumerable<ISpiller> endResult = spil.StartSpil();
        foreach (ISpiller spiller in endResult.OrderByDescending(x => x.SejrsPoint))
        {
            Console.WriteLine($"{spiller.Farve} fik {spiller.SejrsPoint} sejrspoint og {spiller.AntalRubiner} rubiner");
        }

        Console.ReadLine();
    }
}