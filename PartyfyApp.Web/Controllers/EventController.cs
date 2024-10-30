namespace PartyfyApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PartfyApp.Services.Data.Models.Event;
    using PartyfyApp.Data.Models;
    using PartyfyApp.Services.Data;
    using PartyfyApp.Services.Data.Interfaces;
    using PartyfyApp.Web.Infrastructure.Extensions;
    using PartyfyApp.Web.ViewModels.Event;
    using static PartyfyApp.Common.NotificationMessagesConstants;

    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IHosterService _hosterService;
        private readonly ICategoryService _categoryService;

        public EventController(IHosterService hosterService, ICategoryService categoryService, IEventService eventService)
        {
            _eventService = eventService;
            _hosterService = hosterService;
            _categoryService = categoryService;

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllEventsQueryModel queryModel)
        {
            AllEventsFilteredAndPagedServiceModel serviceModel = await _eventService.AllAsync(queryModel);

            queryModel.Events = serviceModel.Events;
            queryModel.TotalEvents = serviceModel.TotalEvents;
            queryModel.Categories = await _categoryService.AllNamesAsync();

            return View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isHoster =
                await _hosterService.HosterExistsByIdAsync(User.GetId());
            if (!isHoster)
            {
                TempData[ErrorMessage] = "You must become a hoster in order to add new houses!";

                return RedirectToAction("Become", "Hoster");
            }

            try
            {
                EventFormViewModel formModel = new EventFormViewModel()
                {
                    Categories = await _categoryService.AllCategoriesAsync(),
                };



                return View(formModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                //return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel model)
        {
            bool isHoster =
                await _hosterService.HosterExistsByIdAsync(User.GetId());
            if (!isHoster)
            {
                TempData[ErrorMessage] = "You must become a hoster in order to add new events!";

                return RedirectToAction("Become", "Hoster");
            }

            bool categoryExists = await _categoryService.ExistsByIdAsync(model.CategoryId);
            if (!categoryExists)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await _categoryService.AllCategoriesAsync();

                return View(model);
            }

            try
            {
                string hosterId = await _hosterService.GetHosterIdAsync(User.GetId());

                string posterImagePath = "";
                if (model.PosterImage != null)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PosterImage.FileName;

                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.PosterImage.CopyToAsync(fileStream);
                    }

                    posterImagePath = $"/images/{uniqueFileName}";
                }

                await _eventService.AddAsync(hosterId, model, posterImagePath);

                TempData[SuccessMessage] = "Event was added successfully!";

                return RedirectToAction("All", "Event");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your event! Please try again later or contact administrator!");
                model.Categories = await _categoryService.AllCategoriesAsync();

                return View(model);
            }
        }

        public async Task<IActionResult> Like(int id)
        {
            bool eventExists = await _eventService.ExistsByIdAsync(id);

            if (!eventExists)
            {
                TempData[ErrorMessage] = "Event with the provided id does not exist!";

                return RedirectToAction("All", "Event");
            }

            try
            {
                string userId = User.GetId();
                await _eventService.LikeAsync(userId, id);

                return RedirectToAction("Liked", "Event");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");

                //return GeneralError();
            }
        }

        public async Task<IActionResult> Liked()
        {
            string userId = User.GetId();
            IEnumerable<EventAllViewModel> model = await _eventService.AllLiked(userId);

            return View(model);
        }

    }
}
