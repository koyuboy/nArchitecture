using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.GithubAccounts.Commands.CreateGithubAccount
{
    public class CreateGithubAccountCommandValidator: AbstractValidator<CreateGithubAccountCommand>
    {
        public CreateGithubAccountCommandValidator()
        {
            RuleFor(c => c.ProfileUrl).NotEmpty();
            RuleFor(c => c.MemberId).NotEmpty();
        }
    }
}
