using AutoMapper;
using PrimeiroInfluencer.Data.DTOs;
using PrimeiroInfluencer.Data.DTOs.Address;
using PrimeiroInfluencer.Model;

namespace PrimeiroInfluencer.ProfileMap
{
    public class AddressMapper : Profile
    {
        public AddressMapper() 
        {
            CreateMap<CreateAddressDto, Address>(); // create post
            CreateMap<UpdateAddressDto, Address>(); // update put
            CreateMap<Address, UpdateAddressDto>(); // update patch
            CreateMap<Address, ReadAddressDto>(); // Read Get
        }
    }
}
