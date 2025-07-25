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
       string GenerateTokenAccess(UserDto userDto);
       string GenerateRefreshToken();
    }
}
