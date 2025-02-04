namespace DebercBackend.Core.GameAggregate;

public class Trick
{
    public int Id { get; set; }

    public Team? WinnerTeam { get; set; }

    public Player? StarterPlayer { get; set; }

    public int Score { get; set; }

    public Round? OwnerRound { get; set; }

    public List<Card> Cards { get; set; } = [];
}