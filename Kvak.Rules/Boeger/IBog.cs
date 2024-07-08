using Kvak.Rules.Chips;

namespace Kvak.Rules.Boeger;

public interface IBog
{
    int ApplyEffect(IChip chip, ISpiller spiller);
}