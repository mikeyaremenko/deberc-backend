using System.Text.Json.Serialization;
using Ardalis.SmartEnum.JsonNet;

namespace DebercBackend.Core.GameAggregate;

public class Combination
{
    public int Id { get; set; }

    [JsonConverter(typeof(SmartEnumNameConverter<CombinationType, int>))]
    public CombinationType Type { get; set; } = CombinationType.Bella;

    public Team? OwnerTeam { get; set; }

    public int Score { get; set; }

    public Round? GameRound { get; set; }
}