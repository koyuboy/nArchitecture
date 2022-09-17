using AutoMapper;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Members.Commands.LoginMember;
using Kodlama.io.Devs.Application.Features.Members.Commands.RegisterMember;
using Kodlama.io.Devs.Application.Features.Members.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Models;

namespace Kodlama.io.Devs.Application.Features.Members.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Member, RegisterMemberCommand>().ReverseMap();
            CreateMap<Member, RegisteredMemberDto>().ReverseMap();
            //CreateMap<Member, LoginMemberCommand>().ReverseMap();
            CreateMap<AccessToken, LoggedMemberDto>().ReverseMap();

        }
    }
}
