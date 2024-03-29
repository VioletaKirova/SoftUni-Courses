﻿namespace FastFood.Web.ViewModels.Items
{
    using System.ComponentModel.DataAnnotations;

    public class CreateItemInputModel
    {
        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [Range(typeof(decimal), "0.0", "500")]
        public decimal Price { get; set; }

        public string CategoryName { get; set; }
    }
}
