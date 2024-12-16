using DebercBackend.Core.GameAggregate;
using DebercBackend.UseCases.Games.Get;

namespace DebercBackend.Web.Games;

/// <summary>
/// Get a Game by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching Game.
/// </remarks>
public class GetById(IMediator _mediator)
  : Endpoint<GetGameByIdRequest, Game>
{
  public override void Configure()
  {
    Get(GetGameByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetGameByIdRequest request, CancellationToken cancellationToken)
  {
    var query = new GetGameQuery(request.GameId);

    var result = await _mediator.Send(query, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
  }
}
