using System.ComponentModel.DataAnnotations;

namespace PrimeiroInfluencer.Data.DTOs
{
    public class ReadProdDto
    {
        public Guid Id { get; set; }
        public string name_prod { get; set; } = string.Empty;
        public string gender_prod { get; set; } = string.Empty;
        public string price_prod { get; set; } = string.Empty;
        public string imageUrl { get; set; } = string.Empty;
    }
}
