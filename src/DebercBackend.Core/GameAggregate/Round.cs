namespace DebercBackend.Core.GameAggregate;

public class Round : EntityBase, IAggregateRoot
{
    public Card? DisplayedCard { get; set; }
    public Player? DutyPlayer { get; set; }
    public int OrderSuit { get; set; }
    public Player? OrderPlayer { get; set; }
    public Player? VotePlayer { get; set; }
    public int BargainRound { get; set; } = 1;
    public Game? OwnerGame { get; set; }
    public List<Trick> Tricks { get; set; } = new List<Trick>();
    public List<Combination> Combinations { get; set; } = new List<Combination>();
}