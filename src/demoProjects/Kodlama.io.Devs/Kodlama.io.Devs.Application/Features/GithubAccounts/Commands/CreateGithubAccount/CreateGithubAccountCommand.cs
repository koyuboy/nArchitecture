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

namespace Kodlama.io.Devs.Application.Features.GithubAccounts.Commands.CreateGithubAccount
{
    public class CreateGithubAccountCommand: IRequest<CreatedGithubAccountDto>
    {
        public int MemberId { get; set; }
        public string ProfileUrl { get; set; }

        public class CreateGithubAccountCommandHandler: IRequestHandler<CreateGithubAccountCommand, CreatedGithubAccountDto>
        {
            private readonly IMapper _mapper;
            private readonly IGithubAccountRepository _githubAccountRepository;
            private readonly GithubAccountsBusinessRules _githubAccountsBusinessRules;

            public CreateGithubAccountCommandHandler(IMapper mapper, IGithubAccountRepository githubAccountRepository, GithubAccountsBusinessRules githubAccountsBusinessRules)
            {
                _mapper = mapper;
                _githubAccountRepository = githubAccountRepository;
                _githubAccountsBusinessRules = githubAccountsBusinessRules;
            }

            public async Task<CreatedGithubAccountDto> Handle(CreateGithubAccountCommand request, CancellationToken cancellationToken)
            {
                await _githubAccountsBusinessRules.GithubProfileUrlCanNotBeDuplicatedWhenInserted(request.ProfileUrl);
                await _githubAccountsBusinessRules.MemberIdCanNotBeDuplicatedWhenInserted(request.MemberId);

                var account = _mapper.Map<GithubAccount>(request);
                var createdAccount = await _githubAccountRepository.AddAsync(account);
                var accountDto = _mapper.Map<CreatedGithubAccountDto>(createdAccount);

                return accountDto;
            }
        }
    }
}
;