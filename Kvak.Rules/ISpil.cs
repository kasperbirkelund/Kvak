using Kvak.Rules.Boeger;
using Kvak.Rules.Heksekort;
using Kvak.Rules.Rundekort;
using Kvak.Rules.Runder;
using Kvak.Rules.Terning;

namespace Kvak.Rules;

public interface ISpil
{
    IBogSamling Boeger { get; }
    IList<ISpiller> Spillere { get; }
    IHekseKortSamling? HekseKortSamling { get; }
    Queue<IRundekort> Rundekort { get; }
    IRunde CurrentRunde { get; }
    IRottehalerCalculator RottehalerCalculator { get; }
    ITerning Terning { get; }
    IEnumerable<ISpiller> StartSpil();
}