﻿using PartyfyApp.Web.ViewModels.Hoster;

namespace PartyfyApp.Services.Data.Interfaces
{
    public interface IHosterService
    {
        Task AddAsync(string userId, BecomeHosterFormModel model);

        Task<bool> HosterExistsByIdAsync(string userId);

        Task<bool> HosterExistsByPhoneNumberAsync(string phoneNumber);

        Task<string> GetHosterIdAsync(string userId);

        Task<bool> HasEventWithId(string hosterId, int eventId);
    }
}
