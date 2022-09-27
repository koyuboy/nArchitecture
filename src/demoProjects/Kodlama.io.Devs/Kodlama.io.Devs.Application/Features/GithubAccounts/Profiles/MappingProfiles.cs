using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Commands.CreateGithubAccount;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Commands.UpdateGithubAccount;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Dtos;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Models;

namespace Kodlama.io.Devs.Application.Features.GithubAccounts.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubAccount, CreateGithubAccountCommand>().ReverseMap();
            CreateMap<GithubAccount, CreatedGithubAccountDto>().ReverseMap();
            CreateMap<GithubAccount, UpdateGithubAccountCommand>().ReverseMap();
            CreateMap<GithubAccount, UpdatedGithubAccountDto>().ReverseMap();
            CreateMap<GithubAccount, DeletedGithubAccountDto>().ReverseMap();
            CreateMap<GithubAccount, GithubAccountGetByIdDto>().ReverseMap();
            CreateMap<IPaginate<GithubAccount>, GithubAccountListModel>().ReverseMap();
            CreateMap<GithubAccount, GithubAccountListDto>().ReverseMap();
        }
    }
}
