using AutoMapper;
using PrimeiroInfluencer.Data.DTOs;
using PrimeiroInfluencer.Model;

namespace PrimeiroInfluencer.ProfileMap
{
    public class ProductMapper : Profile
    {
        public ProductMapper() 
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<UpdateProdDto, Product>();
            CreateMap<Product, UpdateProdDto>();
        }
    }
}
