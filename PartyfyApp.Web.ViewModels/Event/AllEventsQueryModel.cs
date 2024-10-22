namespace PartyfyApp.Web.ViewModels.Event
{
    using System.ComponentModel.DataAnnotations;

    using PartyfyApp.Web.ViewModels.Event.Enum;
    using static PartyfyApp.Common.GeneralApplicationConstants;
    public class AllEventsQueryModel
    {
        public AllEventsQueryModel()
        {
            CurrentPage = CurrentPageByDefault;
            EventsPerPage = EventsPerPageByDefault;

            Categories = new HashSet<string>();
            Events = new HashSet<EventAllViewModel>();
        }

        [Display(Name = "Music type")]
        public string? Category { get; set; }

        [Display(Name = "Search by keyword")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Events by")]
        public EventSorting EventSorting { get; set; }

        public int CurrentPage { get; set; }

        public int EventsPerPage { get; set; }

        public int TotalEvents { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<EventAllViewModel> Events { get; set; }  


    }
}
