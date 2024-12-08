using DebercBackend.Core.GameAggregate;
using DebercBackend.UseCases.Games.List;

namespace DebercBackend.Web.Games;

/// <summary>
/// List all active Games
/// </summary>
public class List(IMediator _mediator) : EndpointWithoutRequest<IEnumerable<Game>>
{
  public override void Configure()
  {
    Get("/Games");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    Result<IEnumerable<Game>> result = await _mediator.Send(new ListGamesQuery(null, null), cancellationToken);
    Response = result.Value;
  }
}