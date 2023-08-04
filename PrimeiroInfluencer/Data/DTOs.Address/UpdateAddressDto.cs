using System.ComponentModel.DataAnnotations;

namespace PrimeiroInfluencer.Data.DTOs.Address
{
    public class UpdateAddressDto
    {
        [Required(ErrorMessage = "I need adress")]
        public string? lougadouro { get; set; } 
        [Required(ErrorMessage = "I need number")]
        public string? numeroDaCasa { get; set; }
    }
}
