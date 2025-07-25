using Shop.Application.DTOs;

namespace Shop.Application.IServices
{
   public interface IAuthenticationService
   {
       public Task<LoginResponseDto> LoginAsync(string userName, string password);
   }
}
