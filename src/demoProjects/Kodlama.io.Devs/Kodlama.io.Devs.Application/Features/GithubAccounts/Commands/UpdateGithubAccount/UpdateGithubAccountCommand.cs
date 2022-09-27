using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Dtos;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.GithubAccounts.Commands.UpdateGithubAccount
{
    public class UpdateGithubAccountCommand:IRequest<UpdatedGithubAccountDto>
    {
        public int Id { get; set; }
        public string ProfileUrl { get; set; }

        public class
            UpdateGithubAccountCommandHandler : IRequestHandler<UpdateGithubAccountCommand, UpdatedGithubAccountDto>
        {
            private readonly IMapper _mapper;
            private readonly IGithubAccountRepository _githubAccountRepository;
            private readonly GithubAccountsBusinessRules _githubAccountsBusinessRules;

            public UpdateGithubAccountCommandHandler(IMapper mapper, IGithubAccountRepository githubAccountRepository, GithubAccountsBusinessRules githubAccountsBusinessRules)
            {
                _mapper = mapper;
                _githubAccountRepository = githubAccountRepository;
                _githubAccountsBusinessRules = githubAccountsBusinessRules;
            }

            public async Task<UpdatedGithubAccountDto> Handle(UpdateGithubAccountCommand request, CancellationToken cancellationToken)
            {
                var githubAccountToUpdate = await _githubAccountRepository.GetAsync(p => p.Id == request.Id);

                _githubAccountsBusinessRules.GithubAccountShouldExistWhenRequested(githubAccountToUpdate);
                await _githubAccountsBusinessRules.GithubProfileUrlCanNotBeDuplicatedWhenUpdated(request.ProfileUrl);

                var githubAccount = _mapper.Map<UpdateGithubAccountCommand, GithubAccount>(request, githubAccountToUpdate);

                var updatedAccount = await _githubAccountRepository.UpdateAsync(githubAccount);
                var updatedAccountDto = _mapper.Map<UpdatedGithubAccountDto>(updatedAccount);

                return updatedAccountDto;
            }
        }
    }
}
