using System.ComponentModel.DataAnnotations;

namespace PrimeiroInfluencer.Data.DTOs
{
    public class ProductCreateDto
    {
        [Required(ErrorMessage = "Do not skip this")]
        public string? name_prod { get; set; }

        [Required(ErrorMessage = "Do not skip this")]
        public string? gender_prod { get; set; }

        [Required(ErrorMessage = "Do not skip this")]
        public double price_prod { get; set; }
    }
}
