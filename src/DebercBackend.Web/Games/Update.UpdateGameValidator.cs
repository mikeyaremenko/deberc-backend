using DebercBackend.Infrastructure.Data.Config;
using FluentValidation;

namespace DebercBackend.Web.Games;

public class UpdateGameValidator : Validator<UpdateGameRequest>
{
  public UpdateGameValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.GAME_NAME_LENGTH);
  }
}
