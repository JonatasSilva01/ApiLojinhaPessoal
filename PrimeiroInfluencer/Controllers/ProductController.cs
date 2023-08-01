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
        private ProductContext _productContext;
        private IMapper _mapper;

        public ProductController(ProductContext productContext, IMapper mapper)
        {
            _productContext = productContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostProd([FromBody] ProductCreateDto prodDto)
        {
            Product _prod = _mapper.Map<Product>(prodDto);

            _prod.qtd_prod++;

            var price = Convert.ToDecimal(_prod.price_prod);

            if (price < 0) BadRequest();

            _productContext.ProductDb.Add(_prod);
            _productContext.SaveChanges();
          
            return CreatedAtAction(nameof(PostProd), new { id = _prod.id }, _prod);
        }

        [HttpGet]
        public IEnumerable<Product> GetProd([FromQuery] int skip = 0, [FromQuery] int Take = 10) 
        {
            return _productContext.ProductDb.Skip(skip).Take(Take);
        }

        [HttpGet("{id}")]
        public IActionResult GetProd(Guid id) 
        {
            var prod = _productContext.ProductDb.FirstOrDefault(x => x.id.Equals(id));
            if (prod == null) NotFound();
            return Ok(prod);

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

            if (user == null) NotFound();

            var ProdMapper = _mapper.Map<UpdateProdDto>(user);

            patch.ApplyTo(ProdMapper, ModelState);

            if (!TryValidateModel(ProdMapper)) return ValidationProblem(ModelState);

            _mapper.Map(ProdMapper, user);
            _productContext.SaveChanges();

            return NoContent();
        }
    }
}
