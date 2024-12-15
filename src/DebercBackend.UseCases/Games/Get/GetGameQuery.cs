using DebercBackend.Core.GameAggregate;

namespace DebercBackend.UseCases.Games.Get;

public record GetGameQuery(string GameId) : IQuery<Result<Game>>;
