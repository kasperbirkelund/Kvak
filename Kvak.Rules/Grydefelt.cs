using Kvak.Rules.Chips;

namespace Kvak.Rules;

public record Grydefelt(int SejrsPoint, bool ErRubinFelt, int KoebsVaerdi) : IComparable<Grydefelt>
{
    public IChip? Chip { get; private set; }
    public void ApplyChip(IChip chip)
    {
        Chip = chip;
    }

    public void FjernChip()
    {
        Chip = null;
    }

    public int CompareTo(Grydefelt? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;

        // Først sammenlign efter KoebsVaerdi
        int koebsVaerdiComparison = KoebsVaerdi.CompareTo(other.KoebsVaerdi);
        if (koebsVaerdiComparison != 0) return koebsVaerdiComparison;

        // Hvis KoebsVaerdi er ens, sammenlign efter ErRubinFelt
        return ErRubinFelt.CompareTo(other.ErRubinFelt);
    }
}
