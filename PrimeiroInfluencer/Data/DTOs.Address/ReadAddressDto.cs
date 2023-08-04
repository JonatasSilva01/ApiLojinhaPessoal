namespace PrimeiroInfluencer.Data.DTOs.Address
{
    public class ReadAddressDto
    {
        public Guid Id { get; set; }
        public string? PublicPlace { get; set; }
        public int NumberHouse { get; set; }
    }
}
