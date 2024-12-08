using DebercBackend.Core.GameAggregate;

namespace DebercBackend.UseCases.Games.List;

public record ListGamesQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<Game>>>;
