using Application.Interfaces.Services;
using Infrastructures.Persistence.Entities;
using Infrastructures.Persistence.SQLServer.Context;

namespace Application.Features.Security.Common
{
    public class TokenHelper(ITokenService tokenService, WritableDbContext context) : ITokenHelper
    {
        public Task<TokenResponse> GenerateTokenAsync(
            UserDao user,
            CancellationToken cancellationToken
        )
        {
            var userRolesId = user.UserRoles.Select(ur => ur.Role.Id).ToList();
            throw new NotImplementedException();
        }

        public Task<UserDao> GetUserForAuthenticationAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
