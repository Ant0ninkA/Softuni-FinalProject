namespace PartyfyApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static PartyfyApp.Common.EntityValidationConstants.Category;
    public class Category
    {
        public Category()
        {
             this.Events = new HashSet<Event>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; } 
    }
}
