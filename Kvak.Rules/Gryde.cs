using Kvak.Rules.Boeger;
using Kvak.Rules.Chips;

namespace Kvak.Rules;

public class Gryde : IGryde
{
    private readonly ISpiller _spiller;

    public Gryde(ISpiller spiller)
    {
        _spiller = spiller;
        EkstraGrydeChips = new List<IChip>();
    }

    public void FlytDraabe(int antal)
    {
        _dropPosition += antal;
    }

    public bool ErEksploderet => _felter.Where(x=> x.Chip is not null && !x.Chip.IsColored).Select(x=> x.Chip).Sum(x=> x!.Vaerdi)> 7;

    public void KlargoerNyRunde()
    {
        foreach (Grydefelt felt in _felter)
        {
            felt.FjernChip();
        }
        _position = _dropPosition;
    }

    public bool ShouldStop()
    {
        IStopStrategi strategy = new ShouldStopStrategi();
        return strategy.ShouldStop(_spiller);
    }

    public Grydefelt GetPosition()
    {
        return _felter[_position];
    }

    private int _position = 0;
    private int _dropPosition = 0;

    public void ApplyChip(IChip chip, IBogSamling boeger)
    {
        _felter[_position].ApplyChip(chip);
        if (chip.IsColored)
        {
            IBog bog = boeger.GetBog(chip.Farve);
            int spacesToMove = bog.ApplyEffect(chip, _spiller);
            _position += spacesToMove;
        }
        else
        {
            int spacesToMove = chip.Vaerdi;
            _position += spacesToMove;
        }
    }

    public IList<IChip> EkstraGrydeChips { get; }

    public void SetRottehaler(int rottehaleAntal)
    {
        _position += rottehaleAntal;
    }

    public IEnumerable<Grydefelt> GetIndhold() => _felter;

    private readonly Grydefelt[] _felter =
    [
        new(0, false, 0),
        new(0, false, 1),
        new(0, false, 2),
        new(0, false, 3),
        new(0, false, 4),
        new(0, false, 5),
        new(0, true, 5),
        new(1, false, 6),
        new(1, false, 7),
        new(1, false, 8),
        new(1, false, 9),
        new(1, true, 9),
        new(2, false, 10),
        new(2, false, 11),
        new(2, false, 12),
        new(2, false, 13),
        new(3, false, 14),
        new(3, false, 15),
        new(3, true, 15),
        new(3, false, 16),
        new(4, true, 16),
        new(4, false, 17),
        new(4, true, 17),
        new(4, false, 18),
        new(5, true, 18),
        new(5, false, 19),
        new(5, true, 19),
        new(5, false, 20),
        new(6, true, 20),
        new(6, false, 21),
        new(6, true, 21),
        new(7, false, 22),
        new(7, true, 22),
        new(7, false, 23),
        new(8, true, 23),
        new(8, false, 24),
        new(8, true, 24),
        new(9, false, 25),
        new(9, true, 25),
        new(9, false, 26),
        new(10, true, 26),
        new(10, false, 27),
        new(10, true, 27),
        new(11, false, 28),
        new(11, true, 28),
        new(11, false, 29),
        new(12, true, 29),
        new(12, false, 30),
        new(12, true, 30),
        new(12, false, 31),
        new(13, true, 31),
        new(13, false, 32),
        new(13, true, 32),
        new(14, false, 33),
        new(14, true, 33),
        new(15, false, 35)
    ];
}