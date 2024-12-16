using DebercBackend.Core.GameAggregate;

namespace DebercBackend.UseCases.Games.Update;

public class UpdateGameHandler(IRepository<Game> _repository)
  : ICommandHandler<UpdateGameCommand, Result<Game>>
{
  public async Task<Result<Game>> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
  {
    var existingGame = await _repository.GetByIdAsync(request.GameId, cancellationToken);
    if (existingGame is null) return Result.NotFound();

    existingGame.Name = request.NewName;
    await _repository.UpdateAsync(existingGame, cancellationToken);

    return existingGame;
  }
}
