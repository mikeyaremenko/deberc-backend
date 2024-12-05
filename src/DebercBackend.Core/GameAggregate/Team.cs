using System.ComponentModel.DataAnnotations;

namespace DebercBackend.Core.GameAggregate;

public class Team: EntityBase, IAggregateRoot
{
    [MaxLength(32)]
    public string Name { get; set; } = string.Empty;
    public int Score { get; set; }
    public Player? FirstPlayer { get; set; }
    public Player? SecondPlayer { get; set; }
}