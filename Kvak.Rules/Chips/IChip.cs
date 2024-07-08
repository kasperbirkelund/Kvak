namespace Kvak.Rules.Chips;

public interface IChip
{
    public ChipFarve Farve { get; }
    public int Vaerdi { get; }
    bool IsColored { get; }
}