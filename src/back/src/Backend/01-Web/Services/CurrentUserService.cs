namespace Web.Services
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
    }
}
