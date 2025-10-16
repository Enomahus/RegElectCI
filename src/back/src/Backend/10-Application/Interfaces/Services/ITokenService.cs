﻿using Application.Models.Auth;
using Infrastructures.Persistence.Entities;

namespace Application.Interfaces.Services
{
    public interface ITokenService
    {
        void TrackRefreshTokensToClean();

        Task<string> CreateRefreshTokenAsync(
            Guid userId,
            CancellationToken cancellationToken = default
        );

        Task<Tokens> CreateTokenAsync(
            UserDao user,
            IEnumerable<string> roles,
            IDictionary<long, IEnumerable<string>> userEntitiesRoles,
            CancellationToken cancellationToken = default
        );
    }
}
