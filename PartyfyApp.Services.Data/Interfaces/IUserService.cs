
namespace PartyfyApp.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsEventLikedAsync(string userId, int eventId);

        Task<string?> GetUserFullNameAsync(string email);
    }
}
