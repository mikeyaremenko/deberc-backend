using System.ComponentModel.DataAnnotations;

namespace DebercBackend.Core.GameAggregate;

public class Card : EntityBase, IAggregateRoot
{
    [MaxLength(16)]
    public string Name { get; set; } = string.Empty;
    public int Suit { get; set; }
    public int Weight { get; set; }
    public int OrderNumber { get; set; }
    public Player? Owner { get; set; }
}