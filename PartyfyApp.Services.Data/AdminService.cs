namespace PartyfyApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using PartyfyApp.Data;
    using PartyfyApp.Services.Data.Interfaces;
    using PartyfyApp.Web.ViewModels.Admin;
    public class AdminService : IAdminService
    {
        private readonly PartyfyAppDbContext _dbContext;

        public AdminService(PartyfyAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DashboardStatsViewModel> GetDashboardStatsAsync()
        {
            DashboardStatsViewModel model = new DashboardStatsViewModel()
            {
                TotalEvents = await _dbContext.Events.CountAsync(),
                TotalUsers = await _dbContext.Users.CountAsync()
            };

            var usersWithTickets = _dbContext.Users.Include(u => u.Tickets);

            foreach (var user in usersWithTickets)
            {
                model.TotalBuyedTickets += user.Tickets.Count();
            }

            return model;

        }
    }
}
