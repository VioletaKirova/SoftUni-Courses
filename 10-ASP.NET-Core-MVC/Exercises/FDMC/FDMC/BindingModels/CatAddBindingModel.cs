namespace FDMC.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CatAddBindingModel
    {
        [Required]
        [StringLength(50, ErrorMessage ="Name must be between 2 and 50 symbols.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Range(0, 200, ErrorMessage = "Age must be between 2 and 200.")]
        public int Age { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Breed must be between 5 and 100 symbols.", MinimumLength = 2)]
        public string Breed { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
