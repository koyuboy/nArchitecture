using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;
using Core.Security.Enums;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Member: User
    {
        public virtual GithubAccount GithubAccount { get; set; }
    }
}
