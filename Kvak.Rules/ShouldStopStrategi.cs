using Kvak.Rules.Chips;

namespace Kvak.Rules;

public class ShouldStopStrategi : IStopStrategi
{
    public int EksplosionsGraense = 7;
    public double Risikovillighed = 0.8; // Juster risikovilligheden mellem 0 (meget forsigtig) og 1 (meget risikovillig)

    public bool ShouldStop(ISpiller spiller)
    {
        string spillerFarve = spiller.Farve.ToString();

        if (spiller.Gryde.ErEksploderet)
        {
            Console.WriteLine($"{spillerFarve} spiller stopper: Gryden er eksploderet.");
            return true;
        }

        int hvidBrikSum = spiller.Gryde.GetPlaceredeChips(chip => chip.Farve == ChipFarve.Hvid).Sum(chip => chip.Vaerdi);
        if (hvidBrikSum > EksplosionsGraense - 2)
        {
            Console.WriteLine($"{spillerFarve} spiller stopper: Summen af hvide brikker ({hvidBrikSum}) nærmer sig eksplosionsgrænsen ({EksplosionsGraense}).");
            return true;
        }

        double farligeChipsSandsynlighed = BeregnFarligeChipsSandsynlighed(spiller.Pose);
        if (farligeChipsSandsynlighed > Risikovillighed)
        {
            Console.WriteLine($"{spillerFarve} spiller stopper: Sandsynligheden for at trække en farlig brik ({farligeChipsSandsynlighed:P}) overstiger risikovilligheden ({Risikovillighed:P}).");
            return true;
        }

        if (spiller.Gryde.GetPlaceredeChips(chip => true).Count() > 10) // Eksempel: Stop hvis spilleren har trukket mere end 10 brikker
        {
            Console.WriteLine($"{spillerFarve} spiller stopper: Spilleren har trukket mere end 10 brikker.");
            return true;
        }

        // Ekstra overvejelser
        // Hvis spilleren er tæt på at vinde eller opnå en vigtig milepæl, kan det være værd at tage en risiko
        if (spiller.SejrsPoint >= 50) // Eksempel: Hvis spilleren er tæt på 50 point, kan de være mere risikovillige
        {
            if (farligeChipsSandsynlighed < 0.75) // Tager en højere risiko hvis tæt på at vinde
            {
                Console.WriteLine($"{spillerFarve} spiller er tæt på at vinde og tager en højere risiko.");
                return false;
            }
        }

        // Hvis spilleren har få rubiner, kan de vælge at tage flere risici for at få flere
        if (spiller.AntalRubiner < 2)
        {
            if (farligeChipsSandsynlighed < 0.6)
            {
                Console.WriteLine($"{spillerFarve} spiller har få rubiner og tager en højere risiko.");
                return false;
            }
        }

        return false;
    }


    private double BeregnFarligeChipsSandsynlighed(ICollection<IChip> pose)
    {
        int farligeChips = pose.Count(chip => chip.Farve == ChipFarve.Hvid);
        int samledeChips = pose.Count;
        if (samledeChips == 0)
        {
            return 0;
        }
        return (double)farligeChips / samledeChips;
    }
}