using FluentValidation;
using System;

namespace BookStore.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(4).When(x => x.Model.Name.Trim() != string.Empty);
            RuleFor(cmd => cmd.Model.DateOfBirth).NotEqual(DateTime.Now.Date);
            RuleFor(cmd => cmd.Model.BookId).GreaterThan(0);
            RuleFor(cmd => cmd.Model.Surname).MinimumLength(2).When(x => x.Model.Surname.Trim() != string.Empty);
        }
    }
}
