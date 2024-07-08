namespace Kvak.Rules.Heksekort;

public interface IHekseKortSamling
{
    IDictionary<MoentFarve, IHekseKort> Heksekort { get; }
}