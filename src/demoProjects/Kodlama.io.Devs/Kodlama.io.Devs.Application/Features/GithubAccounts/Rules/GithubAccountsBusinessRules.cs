using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.GithubAccounts.Rules
{
    public class GithubAccountsBusinessRules
    {
        private readonly IGithubAccountRepository _githubAccountRepository;

        public GithubAccountsBusinessRules(IGithubAccountRepository githubAccountRepository)
        {
            _githubAccountRepository = githubAccountRepository;
        }

        public async Task GithubProfileUrlCanNotBeDuplicatedWhenInserted(string url)
        {
            IPaginate<GithubAccount> result = await _githubAccountRepository.GetListAsync(p => p.ProfileUrl == url);
            if (result.Items.Any()) throw new BusinessException("Profile Url exists.");
        }
        public async Task MemberIdCanNotBeDuplicatedWhenInserted(int memberId)
        {
            IPaginate<GithubAccount> result = await _githubAccountRepository.GetListAsync(p => p.MemberId == memberId);
            if (result.Items.Any()) throw new BusinessException("Member ID exists.");
        }

        public async Task GithubProfileUrlCanNotBeDuplicatedWhenUpdated(string url)
        {
            IPaginate<GithubAccount> result = await _githubAccountRepository.GetListAsync(p => p.ProfileUrl == url);
            if (result.Items.Any()) throw new BusinessException("Profile Url exists.");
        }

        public void GithubAccountShouldExistWhenRequested(GithubAccount githubAccount)
        {
            if (githubAccount == null) throw new BusinessException("Requested Github Account does not exists.");
        }
    }
}
