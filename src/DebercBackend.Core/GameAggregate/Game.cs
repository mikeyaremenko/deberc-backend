using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ardalis.SmartEnum.JsonNet;

namespace DebercBackend.Core.GameAggregate;

public class Game : IAggregateRoot
{
    public int Id { get; set; }

    [MaxLength(32)]
    public string Name { get; set; } = string.Empty;

    public Team? FirstTeam { get; set; }

    public Team? SecondTeam { get; set; }

    public Player? Dealer { get; set; }

    public int OpenPoints { get; set; }

    public List<Round> Rounds { get; set; } = [];
    
    [JsonConverter(typeof(SmartEnumNameConverter<GameStatus, int>))]
    public GameStatus Status { get; set; } = GameStatus.Created;
}