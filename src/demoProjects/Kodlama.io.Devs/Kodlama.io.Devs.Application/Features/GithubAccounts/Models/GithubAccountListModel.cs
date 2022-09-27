using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Dtos;

namespace Kodlama.io.Devs.Application.Features.GithubAccounts.Models
{
    public class GithubAccountListModel: BasePageableModel
    {
        public IList<GithubAccountListDto> Items { get; set; }
    }
}
