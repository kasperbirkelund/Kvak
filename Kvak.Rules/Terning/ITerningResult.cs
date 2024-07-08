namespace Kvak.Rules.Terning;

public interface ITerningResult
{
    void Handle(ISpiller spiller);
}