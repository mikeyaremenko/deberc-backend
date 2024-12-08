using System.ComponentModel.DataAnnotations;

namespace DebercBackend.Core.GameAggregate;

public class Game : EntityBase, IAggregateRoot
{
    [MaxLength(32)]
    public string Name { get; set; } = string.Empty;
    public Team? FirstTeam { get; set; }
    public Team? SecondTeam { get; set; }
    public Player? Dealer { get; set; }
    public int OpenPoints { get; set; }
    public List<Round> Rounds { get; set; } = [];
    public GameStatus Status { get; set; } = GameStatus.Created;
}