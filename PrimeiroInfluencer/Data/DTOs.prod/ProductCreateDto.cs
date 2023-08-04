using System.ComponentModel.DataAnnotations;

namespace PrimeiroInfluencer.Data.DTOs
{
    public class ProductCreateDto
    {
        [Required(ErrorMessage = "u not skip this")]
        public string name_prod { get; set; } = string.Empty;

        [Required(ErrorMessage = "u not skip this")]
        public string gender_prod { get; set; } = string.Empty;

        [Required(ErrorMessage = "I need image")]
        public string imageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "u not skip this")]
        public string price_prod { get; set; } = string.Empty;
    }
}
