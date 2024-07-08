using Kvak.Rules.Chips;

namespace Kvak.Rules.Boeger;

public class BlaaBog1 : IBog
{
    public int ApplyEffect(IChip chip, ISpiller spiller)
    {
        return chip.Vaerdi;
    }
}