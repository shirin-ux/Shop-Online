using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTOs
{
    public class AccessTokenResultDto
    {
        public string Token { get; set; }
        public string JwtId { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
