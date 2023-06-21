using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Util.AuthenticatedUser
{
    public class AuthenticatedUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthenticatedUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Email => _accessor.HttpContext.User.Identity.Name;
        public string Name => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
        public bool EstaAutenticado()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public Guid ObterCompanyId()
        {
            return EstaAutenticado() ? Guid.Parse(_accessor.HttpContext.User.GetCompanyId()) : Guid.Empty;
        }

        public Guid ObterId()
        {
            return EstaAutenticado() ? Guid.Parse(_accessor.HttpContext.User.GetId()) : Guid.Empty;
        }

    }
}
