using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeiroInfluencer.Data;
using PrimeiroInfluencer.Data.DTOs;
using PrimeiroInfluencer.Model;

namespace PrimeiroInfluencer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private DatabaseContext _productContext;
        private IMapper _mapper;

        public ProductController(DatabaseContext productContext, IMapper mapper)
        {
            _productContext = productContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostProd([FromBody] ProductCreateDto prodDto)
        {
            Product _prod = _mapper.Map<Product>(prodDto);

            var price = Convert.ToDecimal(_prod.price_prod);

            if (price < 0) BadRequest();

            if (_prod.imageUrl.Length < 0) BadRequest();

            await _productContext.ProductDb.AddAsync(_prod);
            _productContext.SaveChanges();
          
            return CreatedAtAction(nameof(PostProd), new { id = _prod.id }, _prod);
        }

        [HttpGet]
        public IEnumerable<ReadProdDto> GetProd([FromQuery] int skip = 0, [FromQuery] int Take = 10) 
        {
            return _mapper.Map<List<ReadProdDto>>(_productContext.ProductDb.Skip(skip).Take(Take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProd(Guid id) 
        {
            var prod = await _productContext.ProductDb.FirstOrDefaultAsync(x => x.id.Equals(id));
            if (prod == null) NotFound();
            var prodDto = _mapper.Map<ReadProdDto>(prod);
            return Ok(prodDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateProdDto updateDto)
        {
            var user = await _productContext.ProductDb.FirstOrDefaultAsync(updateUser => updateUser.Equals(id));
            if (user == null) return NotFound();

            _mapper.Map(updateDto, user);
            _productContext.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PachProd(Guid id, [FromBody] JsonPatchDocument<UpdateProdDto> patch)
        {
            var user = await _productContext.ProductDb.FirstOrDefaultAsync(x => x.id.Equals(id));

            var date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            var dateConvert = DateTime.Parse(date);

            if (user == null) NotFound();

            user.update_at = dateConvert;

            var ProdMapper = _mapper.Map<UpdateProdDto>(user);

            patch.ApplyTo(ProdMapper, ModelState);

            if (!TryValidateModel(ProdMapper)) return ValidationProblem(ModelState);

            _mapper.Map(ProdMapper, user);
            _productContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProd(Guid id) 
        {
            var prod = await _productContext.ProductDb.FirstOrDefaultAsync(prod => prod.id.Equals(id));
            if (prod == null) return NotFound();
            _productContext.Remove(prod);
            _productContext.SaveChanges();
            return NoContent();
        }
    }
}
