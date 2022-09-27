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

namespace Kodlama.io.Devs.Application.Features.GithubAccounts.Commands.DeleteGithubAccount
{
    public class DeleteGithubAccountCommand: IRequest<DeletedGithubAccountDto>
    {
        public int Id { get; set; }

        public class
            DeleteGithubAccountCommandHandler : IRequestHandler<DeleteGithubAccountCommand, DeletedGithubAccountDto>
        {
            private readonly IMapper _mapper;
            private readonly IGithubAccountRepository _githubAccountRepository;
            private readonly GithubAccountsBusinessRules _githubAccountsBusinessRules;

            public DeleteGithubAccountCommandHandler(IMapper mapper, IGithubAccountRepository githubAccountRepository, GithubAccountsBusinessRules githubAccountsBusinessRules)
            {
                _mapper = mapper;
                _githubAccountRepository = githubAccountRepository;
                _githubAccountsBusinessRules = githubAccountsBusinessRules;
            }

            public async Task<DeletedGithubAccountDto> Handle(DeleteGithubAccountCommand request, CancellationToken cancellationToken)
            {
                var account = await _githubAccountRepository.GetAsync(p => p.Id == request.Id);

                _githubAccountsBusinessRules.GithubAccountShouldExistWhenRequested(account);

                var deletedAccount = await _githubAccountRepository.DeleteAsync(account);
                var accountDto = _mapper.Map<DeletedGithubAccountDto>(deletedAccount);

                return accountDto;
            }
        }
    }
}
