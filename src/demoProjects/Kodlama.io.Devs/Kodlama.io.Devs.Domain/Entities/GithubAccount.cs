using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class GithubAccount: Entity
    {
        public int MemberId { get; set; }
        public string GithubLink { get; set; }
        public virtual Member Member { get; set; }

        public GithubAccount()
        {

        }

        public GithubAccount(int id, int memberId, string githubLink) : base(id)
        {
            Id = id;
            MemberId = memberId;
            GithubLink = githubLink;
        }

    }
}
