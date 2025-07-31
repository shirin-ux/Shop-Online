using Shop.Application.DTOs;
using Shop.Application.IServices;
using Shop.Application.Public_Tools;
using Shop.Domain.IRepository;
using IAuthenticationService = Shop.Application.IServices.IAuthenticationService;

namespace Shop.Infrastructure.ExternalServices
{
    public class AuthenticationService(
        IUserRepository uerRepository,
        ITokenService tokenService,
        IRefreshTokenRepository refreshTokenRepository)
        : IAuthenticationService
    {
        private readonly IUserRepository _userRepository = uerRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository= refreshTokenRepository;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<LoginResponseDto> LoginAsync(string userName, string password)
        {
            var user = await _userRepository.GetByUserName(userName);
            if (user == null)
                throw new UnauthorizedAccessException("کاربر پیدا نشد");

            if (!PasswordHasher.verifyPassword(password, user.PasswordHash))
                throw new AbandonedMutexException("رمز یا نام کاربری اشتباه میباشد");

            var accessToken = _tokenService.GenerateTokenAccess(new UserDto()
            {
                username = user.UserName,
                role = user.Role,
                id = user.Id
            });
            var refreshToken = await _refreshTokenRepository.GenerateRefreshToken(user, accessToken.JwtId);

            return  new LoginResponseDto()
            {
                AccessToken = accessToken.Token,
                RefreshToken = refreshToken,
                ExpireIn = 900,
                userInfo = new UserDto { id = user.Id, username = user.FullName, role = user.Role }
            };
        }

    }
}
