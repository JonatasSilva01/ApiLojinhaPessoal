using System.ComponentModel.DataAnnotations;

namespace PrimeiroInfluencer.Model
{
    public class Product
    {
        [Key]
        [Required]
        public Guid id { get; set; }

        [Required(ErrorMessage = "Do not skip this")]
        public string? name_prod { get; set; }
        [Required(ErrorMessage = "Do not skip this")]
        public string? gender_prod { get; set; }

        [Required(ErrorMessage = "I need image")]
        public string? imageUrl { get; set; }

        [Required(ErrorMessage = "This field need value")]
        [MaxLength(100, ErrorMessage = "I need price")]
        public string price_prod { get; set; }

        [Display(Name = "creation date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime created_at { get; private set; } = DateTime.Now;

        [Display(Name = "update date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime update_at { get; set; } = DateTime.Now;
    }
}