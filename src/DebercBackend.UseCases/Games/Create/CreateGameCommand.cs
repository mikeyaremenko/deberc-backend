namespace DebercBackend.UseCases.Games.Create;

public record CreateGameCommand(string Name) : ICommand<Result<int>>;
