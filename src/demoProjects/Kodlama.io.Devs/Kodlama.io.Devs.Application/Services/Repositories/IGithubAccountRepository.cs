using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories
{
    public interface IGithubAccountRepository : IRepository<GithubAccount>, IAsyncRepository<GithubAccount>
    {
    }
}
