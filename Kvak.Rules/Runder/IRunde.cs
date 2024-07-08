using Kvak.Rules.Rundekort;
using Kvak.Rules.RundeSteps;

namespace Kvak.Rules.Runder;

public interface IRunde
{
    IRundekort CurrentRundekort { get; }
    IRunde GetNextRunde(ISpil spil);
    bool HasMoreRounds { get; }
    IEnumerable<IRundeStep> GetSteps();
}