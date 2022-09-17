using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Members.Dtos;
using Kodlama.io.Devs.Application.Features.Members.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Members.Commands.LoginMember
{
    public class LoginMemberCommand: UserForLoginDto, IRequest<LoggedMemberDto>
    {
        public class LoginMemberCommandHandler : IRequestHandler<LoginMemberCommand, LoggedMemberDto>
        {
            private readonly IMapper _mapper;
            private readonly MemberBusinessRules _memberBusinessRules;
            private readonly IMemberRepository _memberRepository;
            private readonly ITokenHelper _tokenHelper;

            public LoginMemberCommandHandler(IMapper mapper, MemberBusinessRules memberBusinessRules, IMemberRepository memberRepository, ITokenHelper tokenHelper)
            {
                _mapper = mapper;
                _memberBusinessRules = memberBusinessRules;
                _memberRepository = memberRepository;
                _tokenHelper = tokenHelper;
            }

            public async Task<LoggedMemberDto> Handle(LoginMemberCommand request, CancellationToken cancellationToken)
            {
                var memberToLogin = await _memberRepository.GetAsync(m => m.Email == request.Email);

                _memberBusinessRules.MemberMustExistWhenRequested(memberToLogin);
                _memberBusinessRules.VerifyMemberPassword(request.Password, memberToLogin.PasswordHash, memberToLogin.PasswordSalt);

                List<OperationClaim> operationClaims = new List<OperationClaim>();
                var accesToken = _tokenHelper.CreateToken(memberToLogin, operationClaims);

                var loggedMemberDto = _mapper.Map<LoggedMemberDto>(accesToken);

                return loggedMemberDto;

            }
        }
    }
}
