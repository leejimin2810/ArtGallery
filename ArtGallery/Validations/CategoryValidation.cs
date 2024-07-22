using ArtGallery.Models;
using System.ComponentModel.DataAnnotations;

namespace ArtGallery.Validations
{
    public class CategoryValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var artwork = (Artwork)validationContext.ObjectInstance;

            if (artwork.Category == Category.Auction && artwork.Price.HasValue)
            {
                return new ValidationResult("Auction items should not have a default price.");
            }

            return ValidationResult.Success;
        }
    }
}
