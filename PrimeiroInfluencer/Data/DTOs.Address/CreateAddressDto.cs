using System.ComponentModel.DataAnnotations;

namespace PrimeiroInfluencer.Data.DTOs.Address
{
    public class CreateAddressDto
    {
        [Required(ErrorMessage = "Este campo é necessario ter sido preenchido")]
        public string PublicPlace { get; set; }

        [Required(ErrorMessage = "Este campo é necessario ter sido preenchido")]
        public int NumberHouse { get; set; }
    }
}
