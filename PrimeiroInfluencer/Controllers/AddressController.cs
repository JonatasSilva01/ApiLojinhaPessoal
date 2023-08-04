using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrimeiroInfluencer.Data;
using PrimeiroInfluencer.Data.DTOs.Address;
using PrimeiroInfluencer.Model;

namespace PrimeiroInfluencer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private DatabaseContext _addressContex;
        private IMapper _mapper;

        public AddressController(DatabaseContext addressContex, IMapper mapper)
        {
            _addressContex = addressContex;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressDto address)
        {
            Address _address = _mapper.Map<Address>(address);

            await _addressContex.AddressDb.AddAsync(_address);
            _addressContex.SaveChanges();

            return CreatedAtAction(nameof(CreateAddress), new { id = _address.Id } , _address);
        }

        [HttpGet]
        public IEnumerable<ReadAddressDto> GetAddresses() 
        {
            return _mapper.Map<List<ReadAddressDto>>(_addressContex.AddressDb);
        }

     }
}
