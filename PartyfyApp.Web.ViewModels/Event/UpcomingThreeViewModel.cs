namespace PartyfyApp.Web.ViewModels.Event
{ 
     using PartyfyApp.Services.Mapping;
     using PartyfyApp.Data.Models;
     public class UpcomingThreeViewModel : IMapFrom<Event>
     {
         public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string PosterImagePath { get; set; } = null!;
     }
    
}
