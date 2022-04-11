using MyCarSale.Data;
using MyCarSale.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarSale.Models
{
    public class NewCarVM
    {
        public int Id { get; set; }

        [Display(Name = "Car name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "model name")]
        [Required(ErrorMessage = "Name is required")]
        public string Model { get; set; }

        [Display(Name = "Year name")]
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        [Display(Name = "Color")]
        [Required(ErrorMessage = "Color is required")]
        public string Color { get; set; }

        [Display(Name = "Mileage name")]
        [Required(ErrorMessage = "Mileage is required")]
        public int Mileage { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Car poster URL")]
        [Required(ErrorMessage = "Movie poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Car category is required")]
        public CarCategory CarCategory { get; set; }



        
    }
}
