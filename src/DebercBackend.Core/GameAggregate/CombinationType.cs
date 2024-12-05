namespace DebercBackend.Core.GameAggregate;

public class CombinationType : SmartEnum<CombinationType>
{
  public static readonly CombinationType ThreeCards = new(nameof(ThreeCards), 20);
  public static readonly CombinationType FourCards = new(nameof(FourCards), 50);
  public static readonly CombinationType Bella = new(nameof(Bella), 20);
  public static readonly CombinationType SevenCards = new(nameof(SevenCards), 1001);

  protected CombinationType(string name, int value) : base(name, value) { }
}