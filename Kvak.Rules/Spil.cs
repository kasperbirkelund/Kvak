using Kvak.Rules.Boeger;
using Kvak.Rules.Heksekort;
using Kvak.Rules.Rundekort;
using Kvak.Rules.Runder;
using Kvak.Rules.RundeSteps;
using Kvak.Rules.Terning;

namespace Kvak.Rules;

public class Spil : ISpil
{
    public Spil(IBogSamling boeger, IList<ISpiller> spillere, IHekseKortSamling? hekseKortSamling, Queue<IRundekort> rundekort)
    {
        ValidateSpillere(spillere);

        Boeger = boeger;
        Spillere = spillere;
        HekseKortSamling = hekseKortSamling;
        Rundekort = rundekort;
        CurrentRunde = new Runde1(this);
        RottehalerCalculator = new RottehalerCalculator();
        Terning = new FortuneTerning();
    }

    private static void ValidateSpillere(IList<ISpiller> spillere)
    {
        if(spillere.Count is < 2 or > 5)
        {
            throw new ArgumentException("Spillet skal have mellem 2 og 5 spillere");
        }
        var farver = new HashSet<SpillerFarve>();
        foreach (var spiller in spillere)
        {
            if (!farver.Add(spiller.Farve))
            {
                throw new ArgumentException("Alle spillere skal have forskellige farver");
            }
        }
    }

    public IRunde CurrentRunde { get; private set; }
    public IRottehalerCalculator RottehalerCalculator { get; }
    public ITerning Terning { get; }
    public IBogSamling Boeger { get; }
    public IList<ISpiller> Spillere { get; }
    public IHekseKortSamling? HekseKortSamling { get; }
    public Queue<IRundekort> Rundekort { get; }

    public IEnumerable<ISpiller> StartSpil()
    {
        int count = Spillere.Count;
        for (int i = 0; i < count; i++)
        {
            Spillere[i].HøjreSpiller = Spillere[(i + 1) % count];
            Spillere[i].VenstreSpiller = Spillere[(i - 1 + count) % count];
        }

        //foreach (var spiller in Spillere)
        //{
        //    Console.WriteLine($"{spiller.Farve} - Højre: {spiller.HøjreSpiller.Farve}, Venstre: {spiller.VenstreSpiller.Farve}");
        //}

        while (true)
        {
            foreach (IRundeStep step in CurrentRunde.GetSteps())
            {
                step.Execute();
            }

            if (CurrentRunde.HasMoreRounds)
            {
                CurrentRunde = CurrentRunde.GetNextRunde(this);
            }
            else
            {
                break;
            }
        }
        return Spillere;
    }
}