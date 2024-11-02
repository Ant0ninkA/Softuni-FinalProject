﻿namespace PartyfyApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using PartyfyApp.Data;
    using PartyfyApp.Services.Data.Interfaces;
    public class UserService : IUserService
    {
        private readonly PartyfyAppDbContext _dbContext;

        public UserService(PartyfyAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> IsEventLikedAsync(string userId, int eventId)
        {
            var user = await _dbContext.Users
                .Include(u => u.LikedEvents)
                .FirstAsync(u => u.Id.ToString() == userId);  
            
            return user.LikedEvents.Any(le => le.Id == eventId);
        }

    }
}
