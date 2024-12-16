using FluentValidation;

namespace DebercBackend.Web.Games;

public class GetGameValidator : Validator<GetGameByIdRequest>
{
  public GetGameValidator()
  {
    RuleFor(x => x.GameId)
      .Must(id => id > 0)
      .WithMessage("The Id must be a valid number greater than 0.");
  }
}
