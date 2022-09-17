using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Enums;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Features.Members.Dtos;
using Kodlama.io.Devs.Application.Features.Members.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Members.Commands.RegisterMember
{
    public class RegisterMemberCommand : UserForRegisterDto, IRequest<RegisteredMemberDto>
    {
        public class RegisterMemberCommandHandler : IRequestHandler<RegisterMemberCommand, RegisteredMemberDto>
        {
            private readonly IMemberRepository _memberRepository;
            private readonly IMapper _mapper;
            private readonly MemberBusinessRules _memberBusinessRules;

            public RegisterMemberCommandHandler(IMemberRepository memberRepository, IMapper mapper, MemberBusinessRules memberBusinessRules)
            {
                _memberRepository = memberRepository;
                _mapper = mapper;
                _memberBusinessRules = memberBusinessRules;
            }

            public async Task<RegisteredMemberDto> Handle(RegisterMemberCommand request, CancellationToken cancellationToken)
            {
                await _memberBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(request.Email);

                var member = _mapper.Map<Member>(request);

                byte[] passwordHash, passwordSalt;

                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                member.PasswordHash = passwordHash;
                member.PasswordSalt = passwordSalt;
                member.Status = true;
                member.AuthenticatorType = AuthenticatorType.None;

                var registeredMember = await _memberRepository.AddAsync(member);
                var registedMemberDto = _mapper.Map<RegisteredMemberDto>(registeredMember);

                return registedMemberDto;
            }
        }
    }
}
