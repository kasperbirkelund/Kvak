using Kvak.Rules.Chips;

namespace Kvak.Rules.Boeger;

public class NullBog : IBog
{
    public NullBog(ChipFarve farve)
    {
        Farve = farve;
    }

    public ChipFarve Farve { get; }
    public int BogKode { get; }
    public int ApplyEffect(IChip chip, ISpiller spiller)
    {
        return 1;
    }
}