namespace Kvak.Rules;

public interface IStopStrategi
{
    bool ShouldStop(ISpiller spiller);
}