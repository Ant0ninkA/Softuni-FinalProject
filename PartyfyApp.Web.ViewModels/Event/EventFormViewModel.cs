namespace PartyfyApp.Web.ViewModels.Event
{
    using Microsoft.AspNetCore.Http;
    using PartyfyApp.Web.ViewModels.Category;

    using System.ComponentModel.DataAnnotations;

    using static PartyfyApp.Common.EntityValidationConstants.Event;
    using static PartyfyApp.Common.EntityValidationConstants.Ticket;

    public class EventFormViewModel
    {
        public EventFormViewModel()
        {
            Categories = new HashSet<EventSelectCategoryViewModel>();
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(LocationMaxLength, MinimumLength = LocationMinLength)]
        public string Location { get; set; } = null!;

        [Required]
        [StringLength(DJMaxLength, MinimumLength = DJMinLength)]
        public string DJ { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Required]
        public IFormFile PosterImage { get; set; } = null!;

        public int CategoryId { get; set; }
        public IEnumerable<EventSelectCategoryViewModel> Categories { get; set; }

    }
}
