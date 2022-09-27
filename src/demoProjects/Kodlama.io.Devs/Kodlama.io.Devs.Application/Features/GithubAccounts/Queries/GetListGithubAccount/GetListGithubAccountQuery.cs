using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.GithubAccounts.Queries.GetListGithubAccount
{
    public class GetListGithubAccountQuery: IRequest<GithubAccountListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class
            GetListGithubAccountQueryHandler : IRequestHandler<GetListGithubAccountQuery, GithubAccountListModel>
        {
            private readonly IMapper _mapper;
            private readonly IGithubAccountRepository _githubAccountRepository;

            public GetListGithubAccountQueryHandler(IMapper mapper, IGithubAccountRepository githubAccountRepository)
            {
                _mapper = mapper;
                _githubAccountRepository = githubAccountRepository; 
            }

            public async Task<GithubAccountListModel> Handle(GetListGithubAccountQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GithubAccount> githubAccounts =
                    await _githubAccountRepository.GetListAsync(index: request.PageRequest.Page,
                        size: request.PageRequest.PageSize);

                var githubAccountListModel = _mapper.Map<GithubAccountListModel>(githubAccounts);

                return githubAccountListModel;
            }
        }
    }
}
