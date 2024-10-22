namespace PartfyApp.Services.Data.Models.Event
{
    using PartyfyApp.Web.ViewModels.Event;
    public class AllEventsFilteredAndPagedServiceModel
    {
        public AllEventsFilteredAndPagedServiceModel()
        {
            Events = new HashSet<EventAllViewModel>();
        }
        public int TotalEvents { get; set; }

        public IEnumerable<EventAllViewModel> Events { get; set; }
    }
}
