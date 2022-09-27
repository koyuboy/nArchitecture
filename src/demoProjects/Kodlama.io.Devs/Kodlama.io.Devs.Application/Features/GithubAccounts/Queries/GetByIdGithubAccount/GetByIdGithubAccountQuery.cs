using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Dtos;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.GithubAccounts.Queries.GetByIdGithubAccount
{
    public class GetByIdGithubAccountQuery: IRequest<GithubAccountGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdGithubAccountQueryHandler : IRequestHandler<GetByIdGithubAccountQuery, GithubAccountGetByIdDto>
        {
            private readonly IGithubAccountRepository _githubAccountRepository;
            private readonly IMapper _mapper;
            private readonly GithubAccountsBusinessRules _githubAccountsBusinessRules;

            public GetByIdGithubAccountQueryHandler(IGithubAccountRepository githubAccountRepository, IMapper mapper, GithubAccountsBusinessRules githubAccountsBusinessRules)
            {
                _githubAccountRepository = githubAccountRepository;
                _mapper = mapper;
                _githubAccountsBusinessRules = githubAccountsBusinessRules; 
            }

            public async Task<GithubAccountGetByIdDto> Handle(GetByIdGithubAccountQuery request, CancellationToken cancellationToken)
            {
                var githubAccount = await _githubAccountRepository.GetAsync(x => x.Id == request.Id);
                _githubAccountsBusinessRules.GithubAccountShouldExistWhenRequested(githubAccount);

                var githubAccountDto = _mapper.Map<GithubAccountGetByIdDto>(githubAccount);

                return githubAccountDto;
            }
        }
    }
}
