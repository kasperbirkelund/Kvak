using Kvak.Rules.Boeger;
using Kvak.Rules.Chips;

namespace Kvak.Rules;

public interface IGryde
{
    Grydefelt GetPosition();
    void ApplyChip(IChip chip, IBogSamling boeger);
    IList<IChip> EkstraGrydeChips { get; }
    void SetRottehaler(int rottehaleAntal);
    //List<IChip> TrukneChips { get; }
    void FlytDraabe(int antal);
    bool ErEksploderet { get; }
    void KlargoerNyRunde();
    IEnumerable<Grydefelt> GetIndhold();
    IEnumerable<IChip> GetPlaceredeChips(Func<IChip, bool> predicate) => GetIndhold().Where(x=> x.Chip is not null).Select(x=> x.Chip!).Where(predicate);
    bool ShouldStop();
}