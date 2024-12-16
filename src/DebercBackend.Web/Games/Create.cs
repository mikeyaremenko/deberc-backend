using DebercBackend.UseCases.Games.Create;

namespace DebercBackend.Web.Games;

/// <summary>
/// Create a new Game
/// </summary>
public class Create(IMediator _mediator) : Endpoint<CreateGameRequest, int>
{
  public override void Configure()
  {
    Post(CreateGameRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new CreateGameRequest { Name = "Test Name of the Game" };
    });
  }

  public override async Task HandleAsync(
    CreateGameRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateGameCommand(request.Name), cancellationToken);

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
  }
}
