using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTOs;

namespace Shop.Application.IServices
{
    public interface ITokenService
    {
       AccessTokenResultDto GenerateTokenAccess(UserDto userDto);
       Task<string> GenerateRefreshToken(UserDto user,string jwtId);
    }
}
