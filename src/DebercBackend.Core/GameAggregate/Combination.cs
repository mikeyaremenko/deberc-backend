namespace DebercBackend.Core.GameAggregate;

public class Combination : EntityBase, IAggregateRoot
{
    public CombinationType Type { get; set; } = CombinationType.Bella;
    public Team? OwnerTeam { get; set; }
    public int Score { get; set; }
    public Round? GameRound { get; set; }
}