namespace Kvak.Rules.Patientkort;

public interface IPatientKortSamling
{
    IPatientKort Patient1 { get; }
    IPatientKort Patient2 { get; }
    IPatientKort Patient3 { get; }
}