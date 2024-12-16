using DebercBackend.Core.GameAggregate;
using DebercBackend.UseCases.Games.Get;
using DebercBackend.UseCases.Games.Update;

namespace DebercBackend.Web.Games;

/// <summary>
/// Update an existing Game.
/// </summary>
public class Update(IMediator _mediator)
  : Endpoint<UpdateGameRequest, Game>
{
  public override void Configure()
  {
    Put(UpdateGameRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateGameRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateGameCommand(request.GameId, request.Name!), cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetGameQuery(request.GameId);
    var gameResult = await _mediator.Send(query, cancellationToken);

    if (gameResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (gameResult.IsSuccess)
    {
      Response = gameResult.Value;
    }
  }
}
