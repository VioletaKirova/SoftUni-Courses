namespace Eventures.App.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EventCreateBindingModel
    {
        [Required]
        [MinLength(10, ErrorMessage = "Name must be at least 10 symbols long.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("[^ \t]+", ErrorMessage = "Place is required.")]
        [Display(Name = "Place")]
        public string Place { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start")]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End")]
        public DateTime End { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Total tickets number is invalid.")]
        public int TotalTickets { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335", ErrorMessage = "Price per ticket is invalid.")]
        public decimal PricePerTicket { get; set; }
    }
}
