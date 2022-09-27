using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.GithubAccounts.Dtos
{
    public class DeletedGithubAccountDto
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string ProfileUrl { get; set; }
    }
}
