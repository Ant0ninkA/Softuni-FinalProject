namespace PartyfyApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using PartyfyApp.Services.Data.Interfaces;
    using PartfyApp.Services.Data.Models.Event;
    using PartyfyApp.Web.ViewModels.Event;
    using PartyfyApp.Web.Infrastructure.Extensions;
    using static PartyfyApp.Common.NotificationMessagesConstants;

    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IHosterService _hosterService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;

        public EventController(IHosterService hosterService, ICategoryService categoryService, IEventService eventService, IUserService userService)
        {
            _eventService = eventService;
            _hosterService = hosterService;
            _categoryService = categoryService;
            _userService = userService;
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

        public async Task<IActionResult> Unlike(int id)
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
                await _eventService.UnlikeAsync(userId, id);

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
        
        public async Task<IActionResult> Details(int id)
        {
            bool eventExists = await _eventService
                .ExistsByIdAsync(id);
            if (!eventExists)
            {
                TempData[ErrorMessage] = "Event with the provided id does not exist!";

                return RedirectToAction("All", "Event");
            }

            try
            {
                EventDetailsViewModel model = await _eventService.GetEventDetailsAsync(id);
                model.IsLiked =
                    await _userService.IsEventLikedAsync(User.GetId(), id);

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");

                //return GeneralError();
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool eventExists = await _eventService
                .ExistsByIdAsync(id);
            if (!eventExists)
            {
                TempData[ErrorMessage] = "Event with the provided id does not exist!";

                return RedirectToAction("All", "Event");

                //return this.NotFound(); -> If you want to return 404 page
            }

            bool isUserHoster = await _hosterService
                .HosterExistsByIdAsync(User.GetId()!);
            if (!isUserHoster  && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must become a hoster in order to edit event info!";

                return RedirectToAction("Become", "Agent");
            }

            string? hosterId =
                await _hosterService.GetHosterIdAsync(User.GetId()!);
            bool isHosterOfEvent = await _hosterService
                .HasEventWithId(hosterId, id);
            if (!isHosterOfEvent && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be the hoster of the event you want to edit!";

                return RedirectToAction("Mine", "Event");
            }

            try
            {
                EventFormViewModel model = await _eventService
                    .GetEventForEditByIdAsync(id);
                model.Categories = await _categoryService.AllCategoriesAsync();

                return View(model);
            }
            catch (Exception)
            {
                //return GeneralError();

                return RedirectToAction("All", "Event");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await _categoryService.AllCategoriesAsync();

                return View(model);
            }

            bool eventExists = await _eventService
                .ExistsByIdAsync(id);
            if (!eventExists)
            {
                TempData[ErrorMessage] = "Event with the provided id does not exist!";

                return RedirectToAction("All", "Event");

                //return this.NotFound(); -> If you want to return 404 page
            }

            bool isUserHoster = await _hosterService
                .HosterExistsByIdAsync(User.GetId()!);
            if (!isUserHoster  && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must become a hoster in order to edit event info!";

                return RedirectToAction("Become", "Agent");
            }

            string? hosterId =
                await _hosterService.GetHosterIdAsync(User.GetId()!);
            bool isHosterOfEvent = await _hosterService
                .HasEventWithId(hosterId, id);
            if (!isHosterOfEvent && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be the hoster of the event you want to edit!";

                return RedirectToAction("Mine", "Event");
            }

            try
            {
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
                await _eventService.EditEventAsync(id, posterImagePath, model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to update the event. Please try again later or contact administrator!");
                model.Categories = await _categoryService.AllCategoriesAsync();

                return View(model);
            }

            TempData[SuccessMessage] = "Event was edited successfully!";
            return RedirectToAction("Details", "Event", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool eventExists = await _eventService
                .ExistsByIdAsync(id);
            if (!eventExists)
            {
                TempData[ErrorMessage] = "Event with the provided id does not exist!";

                return RedirectToAction("All", "Event");

                //return this.NotFound(); -> If you want to return 404 page
            }

            bool isUserHoster = await _hosterService
                .HosterExistsByIdAsync(User.GetId()!);
            if (!isUserHoster  && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must become a hoster in order to delete an event!";

                return RedirectToAction("Become", "Agent");
            }

            string? hosterId =
                await _hosterService.GetHosterIdAsync(User.GetId()!);
            bool isHosterOfEvent = await _hosterService
                .HasEventWithId(hosterId, id);
            if (!isHosterOfEvent && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be the hoster of the event you want to delete!";

                return RedirectToAction("Mine", "Event");
            }

            try
            {
                EventPreDeleteViewModel model =
                    await _eventService.GetEventForDeleteByIdAsync(id);

                return View(model);
            }
            catch (Exception)
            {
                //return GeneralError();

                return RedirectToAction("All", "Event");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, EventPreDeleteViewModel model)
        {
            bool eventExists = await _eventService
                 .ExistsByIdAsync(id);
            if (!eventExists)
            {
                TempData[ErrorMessage] = "Event with the provided id does not exist!";

                return RedirectToAction("All", "Event");

                //return this.NotFound(); -> If you want to return 404 page
            }

            bool isUserHoster = await _hosterService
                .HosterExistsByIdAsync(User.GetId()!);
            if (!isUserHoster  && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must become a hoster in order to delete an event!";

                return RedirectToAction("Become", "Agent");
            }

            string? hosterId =
                await _hosterService.GetHosterIdAsync(User.GetId()!);
            bool isHosterOfEvent = await _hosterService
                .HasEventWithId(hosterId, id);
            if (!isHosterOfEvent && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be the hoster of the event you want to delete!";

                return RedirectToAction("Mine", "Event");
            }

            try
            {
                await _eventService.DeleteEventAsync(id);

                TempData[WarningMessage] = "The house was successfully deleted!";
                return RedirectToAction("Mine", "House");
            }
            catch (Exception)
            {
                //return GeneralError();

                return RedirectToAction("All", "Event");
            }
        }

    }
}
