namespace PartyfyApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using PartyfyApp.Data;
    using PartyfyApp.Data.Models;
    using PartyfyApp.Services.Data.Interfaces;
    using PartyfyApp.Web.ViewModels.Hoster;

    public class HosterService : IHosterService
    {
        private readonly PartyfyAppDbContext _dbContext;

        public HosterService(PartyfyAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(string userId, BecomeHosterFormModel model)
        {
            Hoster newHoster = new Hoster()
            {
                PhoneNumber = model.PhoneNumber,
                UserId = Guid.Parse(userId)
            };

            await _dbContext.Hosters.AddAsync(newHoster);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> GetHosterIdAsync(string userId)
        {
            Hoster? hoster = await _dbContext
                .Hosters
                .FirstOrDefaultAsync(a => a.UserId.ToString() == userId);

            if (hoster == null)
            {
                return null;
            }

            return hoster.Id.ToString();
        }

        public async Task<bool> HasEventWithId(string hosterId, int eventId)
        {

            Hoster? hoster =  await _dbContext.Hosters
                .Include(h => h.MyEvents)
                .FirstOrDefaultAsync(h => h.Id.ToString() == hosterId);

            if(hoster == null)
            {
                return false;
            }

            return hoster.MyEvents.Any(e => e.Id == eventId);
        }

        public async Task<bool> HosterExistsByIdAsync(string userId)
        {
            return await _dbContext.Hosters.AnyAsync(h => h.UserId.ToString() == userId);
        }

        public async Task<bool> HosterExistsByPhoneNumberAsync(string phoneNumber)
        {
            return await _dbContext.Hosters.AnyAsync(h => h.PhoneNumber == phoneNumber);
        }
    }
}
