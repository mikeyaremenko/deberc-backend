using DebercBackend.Core.GameAggregate;

namespace DebercBackend.UseCases.Games.Update;

public record UpdateGameCommand(int GameId, string NewName) : ICommand<Result<Game>>;
