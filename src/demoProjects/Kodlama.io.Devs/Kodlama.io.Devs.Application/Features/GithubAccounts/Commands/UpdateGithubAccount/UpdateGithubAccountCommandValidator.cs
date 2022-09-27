using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.GithubAccounts.Commands.UpdateGithubAccount
{
    public class UpdateGithubAccountCommandValidator: AbstractValidator<UpdateGithubAccountCommand>
    {
        public UpdateGithubAccountCommandValidator()
        {
            RuleFor(c => c.ProfileUrl).NotEmpty();
        }
    }
}
