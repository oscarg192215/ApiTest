using ApiTest.Models;
using ApiTest.Models.DTO;
using ApiTest.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTraceController : ControllerBase
    {
        private readonly IPropertyTraceRepository _propertyTraceRepository;
        private readonly IMapper _mapper;

        public PropertyTraceController(IPropertyTraceRepository propertyTraceRepository, IMapper mapper)
        {
            _propertyTraceRepository = propertyTraceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var propertyTraces = await _propertyTraceRepository.GetPropertyTraces();
                if (propertyTraces != null) 
                    return Ok(propertyTraces);
                else 
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new {error=ex.InnerException?.Message});
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var propertyTrace = await _propertyTraceRepository.GetPropertyTraceById(id);
                if (propertyTrace != null) 
                    return Ok(propertyTrace);
                else 
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error=ex.InnerException?.Message});
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PropertyTraceDTO propertyTraceDto)
        {
            try
            {
                var propertyTrace = _mapper.Map<PropertyTrace>(propertyTraceDto);
                await _propertyTraceRepository.AddPropertyTrace(propertyTrace);
                propertyTrace = await _propertyTraceRepository.GetPropertyTraceById(propertyTrace.IdPropertyTrace);
                return Ok(new { message ="Property Trace creada correctamente", propertyTrace });
            }
            catch (Exception ex)
            {
                return BadRequest(new {error= ex.InnerException?.Message});
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(PropertyTraceDTO propertyTraceDto)
        {
            try
            {
                var propertyTrace = _mapper.Map<PropertyTrace>(propertyTraceDto);
                await _propertyTraceRepository.UpdatePropertyTrace(propertyTrace);
                propertyTrace = await _propertyTraceRepository.GetPropertyTraceById(propertyTrace.IdPropertyTrace);
                return Ok(new { message ="Property Trace actualizada correctamente", propertyTrace });
            }
            catch (Exception ex)
            {
                return BadRequest(new {error=ex.InnerException?.Message});                
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var propertyTrace = await _propertyTraceRepository.GetPropertyTraceById(id);
                await _propertyTraceRepository.DeletePropertyTrace(propertyTrace);
                return Ok(new { message ="Property Trace eliminada correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error=ex.InnerException?.Message});
            }
        }
    }
}
