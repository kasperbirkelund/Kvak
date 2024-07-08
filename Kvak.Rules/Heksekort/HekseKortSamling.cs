namespace Kvak.Rules.Heksekort;

public class HekseKortSamling : IHekseKortSamling
{
    private HekseKortSamling(IDictionary<MoentFarve, IHekseKort> heksekort)
    {
        Heksekort = heksekort;
    }

    public IDictionary<MoentFarve, IHekseKort> Heksekort { get; }
}