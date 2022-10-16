using Microsoft.AspNetCore.Mvc;
using WebAppMvc.Models;
using WebAppMvc.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppMvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {

        IProductService _productService;
        public ProductApiController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductApiController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.GetAll());
        }

        // GET api/<ProductApiController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var data = _productService.GetById(id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        // POST api/<ProductApiController>
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            _productService.Add(value);
            return StatusCode(StatusCodes.Status201Created);
        } 

        // DELETE api/<ProductApiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var product = _productService.GetById(id);
            if (product == null)
                return NotFound();
            _productService.Remove(id);
            return Ok(true);
        }
    }
}
