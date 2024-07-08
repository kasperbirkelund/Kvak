using Kvak.Rules.Chips;

namespace Kvak.Rules.Boeger;

public class BogSamling : IBogSamling
{
    public BogSamling(IDictionary<ChipFarve, IBog> boeger)
    {
        // Tjek at alle chipfarver undtagen hvid er sat
        var requiredColors = Enum.GetValues(typeof(ChipFarve)).Cast<ChipFarve>().Where(c => c != ChipFarve.Hvid);
        var missingColors = requiredColors.Where(c => !boeger.ContainsKey(c)).ToList();

        if (missingColors.Any())
        {
            throw new ArgumentException($"Følgende chipfarver mangler i bogsamlingen: {string.Join(", ", missingColors)}");
        }

        Boeger = boeger;
    }

    public IDictionary<ChipFarve, IBog> Boeger { get; }
    public IBog GetBog(ChipFarve chipFarve)
    {
        return Boeger[chipFarve];
    }
}