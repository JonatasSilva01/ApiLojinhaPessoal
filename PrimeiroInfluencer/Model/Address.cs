using System.ComponentModel.DataAnnotations;

namespace PrimeiroInfluencer.Model
{
    public class Address
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é necessario ter sido preenchido")]
        public string PublicPlace { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo é necessario ter sido preenchido")]
        public string NumberHouse { get; set; } = string.Empty;
      
    }
}
