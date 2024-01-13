using ApiTest.Models;
using ApiTest.Models.DTO;
using ApiTest.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IPropertyImageRepository _propertyImageRepository;
        private readonly IPropertyTraceRepository _propertyTraceRepository;
        private readonly IMapper _mapper;

        public PropertyController(IPropertyRepository propertyRepository, IPropertyImageRepository propertyImageRepository, IPropertyTraceRepository propertyTraceRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _propertyImageRepository = propertyImageRepository;
            _propertyTraceRepository = propertyTraceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var properties = await _propertyRepository.GetProperties();
                if (properties != null)
                    return Ok(new { message = "Properties encontradas", result = true, data = properties });
                else
                    return Ok(new { message = "Properties no encontradas", result = true });
            }
            catch (Exception ex)
            {
                return Ok(new { message = "Properties no encontradas", result = true });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var property = await _propertyRepository.GetPropertyById(id);
                if (property != null)
                    return Ok(new { message = "Property encontrada", result = true, data = property });
                else
                    return Ok(new { message = "Property no encontrada", result = true });
            }
            catch (Exception ex)
            {
                return Ok(new { message = "Property no encontrada", result = true });
            }
        }        
            
        [HttpPost]
        public async Task<IActionResult> Post(PropertyDTO propertyDto)
        {
            try
            {
                List<PropertyImage> propertyImagesList = new();
                List<PropertyTrace> propertyTraceList = new();

                if (propertyDto.PropertyImage != null)
                    propertyImagesList.Add(propertyDto.PropertyImage);

                if (propertyDto.PropertyTrace != null)
                    propertyTraceList.Add(propertyDto.PropertyTrace);

                Property property = new Property()
                {
                    Address = propertyDto.Address,
                    CodeInternal = propertyDto.CodeInternal,
                    IdOwner = propertyDto.IdOwner,
                    IdProperty = propertyDto.IdProperty,
                    Name = propertyDto.Name,
                    Price = propertyDto.Price,
                    Year = propertyDto.Year,
                    PropertyTrace = propertyTraceList,
                    PropertyImage = propertyImagesList
                };

                await _propertyRepository.AddProperty(property);
                property = await _propertyRepository.GetPropertyById(property.IdProperty);
                return Ok(new { message = "Property creada correctamente", result = true, data = property });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Property no creada", result = false });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(PropertyDTO propertyDto)
        {
            try
            {
                List<PropertyImage> propertyImagesList = new();
                List<PropertyTrace> propertyTraceList = new();

                if (propertyDto.PropertyImage != null)
                    propertyImagesList.Add(propertyDto.PropertyImage);

                if (propertyDto.PropertyTrace != null)
                    propertyTraceList.Add(propertyDto.PropertyTrace);

                Property property = new Property()
                {
                    Address = propertyDto.Address,
                    CodeInternal = propertyDto.CodeInternal,
                    IdOwner = propertyDto.IdOwner,
                    IdProperty = propertyDto.IdProperty,
                    Name = propertyDto.Name,
                    Price = propertyDto.Price,
                    Year = propertyDto.Year,
                    PropertyTrace = propertyTraceList,
                    PropertyImage = propertyImagesList
                };
                
                await _propertyRepository.UpdateProperty(property);
                property = await _propertyRepository.GetPropertyById(property.IdProperty);
                
                return Ok(new { message = "Property actualizada correctamente", result = true, data = property });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Property no actualizada", result = false });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _propertyRepository.DeleteProperty(id);
                return Ok(new { message = "Property actualizada correctamente", result = true});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Property no eliminada", result = false });
            }
        }
    }
}
