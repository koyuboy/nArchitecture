using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Hashing;

namespace Kodlama.io.Devs.Application.Features.Members.Rules
{
    public class MemberBusinessRules
    {
        private readonly IMemberRepository _memberRepository;

        public MemberBusinessRules(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }


        public void MemberMustExistWhenRequested(Member member)
        {
            if (member == null) throw new BusinessException("Member must exist.");
        }

        public async Task CheckIsMemberExistByIdAsync(int id)
        {
            Member? member = await _memberRepository.GetAsync(m => m.Id == id);
            MemberMustExistWhenRequested(member);
        }

        public void VerifyMemberPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            bool verified = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!verified) throw new AuthorizationException("Entered password is wrong");

        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            var result = await _memberRepository.GetAsync(u => u.Email.ToLower().Equals(email.ToLower()));
            if (result != null) throw new BusinessException("Member email already exists.");
        }

    }
}
