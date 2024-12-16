using DebercBackend.Core.GameAggregate;

namespace DebercBackend.UseCases.Games.Create;

public class CreateGameHandler(IRepository<Game> _repository)
  : ICommandHandler<CreateGameCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateGameCommand request,
    CancellationToken cancellationToken)
  {
    var newGame = new Game() { Name = request.Name };
    var createdItem = await _repository.AddAsync(newGame, cancellationToken);

    return createdItem.Id;
  }
}
