using ApiTest.Models;
using ApiTest.Models.DTO;
using ApiTest.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        private readonly IPropertyImageRepository _propertyImageRepository;
        private readonly IMapper _mapper;

        public PropertyImageController(IPropertyImageRepository propertyImageRepository, IMapper mapper)
        {
            _propertyImageRepository = propertyImageRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var propertyImages = await _propertyImageRepository.GetPropertyImages();
                if(propertyImages != null)
                    return Ok(propertyImages);
                else 
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message =ex.InnerException?.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var propertyImage = await _propertyImageRepository.GetPropertyImageById(id);
                if (propertyImage != null)
                    return Ok(propertyImage);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message =ex.InnerException?.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PropertyImageDTO propertyImageDto)
        {
            try
            {
                var propertyImage = _mapper.Map<PropertyImage>(propertyImageDto);
                await _propertyImageRepository.AddPropertyImage(propertyImage);

                propertyImage = await _propertyImageRepository.GetPropertyImageById(propertyImage.IdPropertyImage);
                return Ok(new { message ="Property Image creada correctamente", propertyImage });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message =ex.InnerException?.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(PropertyImageDTO propertyImageDto)
        {
            try
            {
                var propertyImage = _mapper.Map<PropertyImage>(propertyImageDto);
                await _propertyImageRepository.UpdatePropertyImage(propertyImage);
                propertyImage = await _propertyImageRepository.GetPropertyImageById(propertyImage.IdPropertyImage);
                return Ok(new { message ="Property Image creada correctamente" , propertyImage});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message =ex.InnerException?.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            try
            {
                var propertyImage = await _propertyImageRepository.GetPropertyImageById(id);
                await _propertyImageRepository.DeletePropertyImage(propertyImage);
                return Ok(new { message ="Property Image eliminada correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message =ex.InnerException?.Message});
            }
        }

    }
}
