using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandValidator: AbstractValidator<UpdateTechnologyCommand>
    {
        
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty();
            RuleFor(u => u.ProgrammingLanguageId).NotEmpty();
        }
    }
}
