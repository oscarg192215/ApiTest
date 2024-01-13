using ApiTest.Models;
using ApiTest.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyDetailsController : ControllerBase
    {
        private readonly IPropertyDetailsRepository _propertyDetailsRepository;

        public PropertyDetailsController(IPropertyDetailsRepository propertyDetailsRepository)
        {
            _propertyDetailsRepository = propertyDetailsRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _propertyDetailsRepository.GetPropertyDetails();
            return Ok(new { message = "Listado encontrado", result = true, data = lista });
        }
        [HttpGet("GetDetailsById")]
        public async Task<IActionResult> GetDetailsById(int id)
        {
            var lista = await _propertyDetailsRepository.GetDetailsById(id);
            return Ok(new { message = "Lista por owner encontrada", result = true, data = lista });
        }
    }
}
