using Kvak.Rules.Boeger;
using Kvak.Rules.Chips;
using Kvak.Rules.Heksekort;
using Kvak.Rules.Patientkort;

namespace Kvak.Rules;

public interface ISpiller
{
    ISpiller HøjreSpiller { get; internal set; }
    ISpiller VenstreSpiller { get; internal set; }
    int SejrsPoint { get; }
    IPatientKort? PatientKort { get; }
    IGryde Gryde { get; }
    List<IChip> Pose { get; }
    SpillerFarve Farve { get; }
    int AntalRubiner { get; }
    IMoent? Guld { get; }
    IMoent? Soelv { get; }
    IMoent? Bronze { get; }
    void TraekBrikker(IBogSamling boeger);
    void TildelSejrsPoints(int antal);
    void TildelRubiner(int antal);
    void KlargoerNyRunde();
}