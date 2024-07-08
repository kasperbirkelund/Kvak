using Kvak.Rules.Boeger;
using Kvak.Rules.Chips;
using Kvak.Rules.Heksekort;
using Kvak.Rules.Patientkort;

namespace Kvak.Rules;

public class Spiller : ISpiller
{
    public Spiller(IPatientKort? patientKort, SpillerFarve farve)
    {
        PatientKort = patientKort;
        Gryde = new Gryde(this);
        Pose = new List<IChip>
        {
            new Chip(ChipFarve.Hvid, 1),
            new Chip(ChipFarve.Hvid, 1),
            new Chip(ChipFarve.Hvid, 1),
            new Chip(ChipFarve.Hvid, 1),
            new Chip(ChipFarve.Hvid, 2),
            new Chip(ChipFarve.Hvid, 2),
            new Chip(ChipFarve.Hvid, 3),
            new Chip(ChipFarve.Groen, 1),
            new Chip(ChipFarve.Orange, 1),
        };
        Farve = farve;
        AntalRubiner = 1;
        Guld = new Moent(MoentFarve.Guld);
        Soelv = new Moent(MoentFarve.Soelv);
        Bronze = new Moent(MoentFarve.Bronze);
        SejrsPoint = 0;
    }

    public ISpiller HøjreSpiller { get; set; }
    public ISpiller VenstreSpiller { get; set; }
    public int SejrsPoint { get; private set; }
    public IPatientKort? PatientKort { get; }
    public IGryde Gryde { get; }
    public List<IChip> Pose { get; }
    public SpillerFarve Farve { get; }
    public int AntalRubiner { get; private set; }
    public IMoent? Guld { get; }
    public IMoent? Soelv { get; }
    public IMoent? Bronze { get; }

    public void KlargoerNyRunde()
    {
        Pose.AddRange(Gryde.GetIndhold().Where(x=> x.Chip is not null).Select(x => x.Chip!));
        Gryde.KlargoerNyRunde();
    }

    public void TraekBrikker(IBogSamling boeger)
    {
        while (true)
        {
            int index = Random.Shared.Next(Pose.Count);
            IChip chip = Pose[index];
            Pose.RemoveAt(index);
            Gryde.ApplyChip(chip, boeger);
            if (Gryde.ShouldStop())
            {
                return;
            }
        }
    }

    public void TildelSejrsPoints(int antal)
    {
        SejrsPoint+= antal;
    }

    public void TildelRubiner(int antal)
    {
        AntalRubiner += antal;
    }
}