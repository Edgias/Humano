using Edgias.Humano.ApplicationCore.Interfaces;

namespace Edgias.Humano.WebApp.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor
            /*UserManager<ApplicationUser> userManager*/)
        {
            _httpContextAccessor = httpContextAccessor;
            //_userManager = userManager;
        }

        public async Task<string> GetUserId()
        {
            string? userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name;

            //ApplicationUser? user = await _userManager.FindByNameAsync(userName);

            return userName!;
        }
    }
}
