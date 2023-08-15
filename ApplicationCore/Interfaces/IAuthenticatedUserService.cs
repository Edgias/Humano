namespace Edgias.Humano.ApplicationCore.Interfaces
{
    public interface IAuthenticatedUserService
    {
        Task<string> GetUserId();
    }
}
