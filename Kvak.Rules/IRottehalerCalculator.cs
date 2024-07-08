using Kvak.Rules.Rundekort;

namespace Kvak.Rules;

public interface IRottehalerCalculator
{
    IEnumerable<Rottehaler> CountRottehaler(IList<ISpiller> spillere, IRundekort currentRundeCurrentRundekort);
}