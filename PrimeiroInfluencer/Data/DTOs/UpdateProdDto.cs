using System.ComponentModel.DataAnnotations;

namespace PrimeiroInfluencer.Data.DTOs
{
    public class UpdateProdDto
    {
        [Required(ErrorMessage = "Do not skip this")]
        public string? name_prod { get; set; }

        [Required(ErrorMessage = "Do not skip this")]
        public string? gender_prod { get; set; }

        [Required(ErrorMessage = "Do not skip this")]
        public string? price_prod { get; set; }
    }
}
