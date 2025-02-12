namespace PartyfyApp.Services.Data.Interfaces
{
    using PartyfyApp.Web.ViewModels.Admin;
    public interface IAdminService
    {
        public Task<DashboardStatsViewModel> GetDashboardStatsAsync();
    }
}
