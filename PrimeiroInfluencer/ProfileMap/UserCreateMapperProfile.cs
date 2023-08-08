using AutoMapper;
using PrimeiroInfluencer.Model;
using PrimeiroInfluencer.Data.DTOs.user;

namespace CadastroDeUsuario.ProfileMapper
{
    public class UserCreateMapperProfile : Profile
    {
        public UserCreateMapperProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}
