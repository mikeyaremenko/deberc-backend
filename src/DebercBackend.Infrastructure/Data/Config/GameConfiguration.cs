using DebercBackend.Core.GameAggregate;

namespace DebercBackend.Infrastructure.Data.Config;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
  public void Configure(EntityTypeBuilder<Game> builder)
  {
    builder.Property(x => x.Status)
      .HasConversion(
          x => x.Value,
          x => GameStatus.FromValue(x));
  }
}
