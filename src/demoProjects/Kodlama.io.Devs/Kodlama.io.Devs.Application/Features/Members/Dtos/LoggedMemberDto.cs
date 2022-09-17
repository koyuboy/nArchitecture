using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Members.Dtos
{
    public class LoggedMemberDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
