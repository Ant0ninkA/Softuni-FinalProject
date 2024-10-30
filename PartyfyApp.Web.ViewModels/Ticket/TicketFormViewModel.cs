namespace PartyfyApp.Web.ViewModels.Ticket
{
    using System.ComponentModel.DataAnnotations;
    using static PartyfyApp.Common.EntityValidationConstants.Ticket;
    public class TicketFormViewModel
    {
        public TicketFormViewModel()
        {
           
        }
        public int EventId { get; set; }

        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal VipPrice { get; set; }

        [Required]
        [Range(QuantityMinValue, QuantityMaxValue)]
        public int VipQuantity { get; set; }

        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal StandardPrice { get; set; }

        [Required]
        [Range(QuantityMinValue, QuantityMaxValue)]
        public int StandardQuantity { get; set; }

        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal StandingPrice { get; set; }

        [Required]
        [Range(QuantityMinValue, QuantityMaxValue)]
        public int StandingQuantity { get; set; }
    }
}
