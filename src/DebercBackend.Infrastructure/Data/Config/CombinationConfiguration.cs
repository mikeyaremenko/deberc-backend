using DebercBackend.Core.GameAggregate;

namespace DebercBackend.Infrastructure.Data.Config;

public class CombinationConfiguration : IEntityTypeConfiguration<Combination>
{
  public void Configure(EntityTypeBuilder<Combination> builder)
  {
    builder.Property(x => x.Type)
      .HasConversion(
          x => x.Value,
          x => CombinationType.FromValue(x));
  }
}
