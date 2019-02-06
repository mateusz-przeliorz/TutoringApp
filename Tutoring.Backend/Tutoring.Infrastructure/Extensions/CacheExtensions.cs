using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using Tutoring.Infrastructure.Dtos;

namespace Tutoring.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache memoryCache, Guid tokenId, JwtDto jwtDto)
        {
            memoryCache.Set(GetJwtKey(tokenId), jwtDto, TimeSpan.FromSeconds(5));
        }

        public static JwtDto GetJwt(this IMemoryCache memoryCache, Guid tokenId)
        {
            return memoryCache.Get<JwtDto>(GetJwtKey(tokenId));
        }

        private static string GetJwtKey(Guid tokenId)
        {
            return $"jwt-{tokenId}";
        }
    }
}
