namespace Kvak.Rules.Chips;

public record Chip(ChipFarve Farve, int Vaerdi) : IChip
{
    public bool IsColored => Farve != ChipFarve.Hvid;
}