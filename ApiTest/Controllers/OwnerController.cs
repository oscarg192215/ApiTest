using ApiTest.Models;
using ApiTest.Models.DTO;
using ApiTest.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ownersEntity = await _ownerRepository.GetOwners();
                var owners = _mapper.Map<List<OwnerDTO>>(ownersEntity);
                if (owners == null)
                {
                    return BadRequest(new { message = "Owners no encontrados", result = false });
                }
                return Ok(new { message = "Owners encontrados", result = true, data = owners });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Owners no encontrados", result = false });
            }         
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwnerById(int id)
        {
            try
            {
                var ownerEntity = await _ownerRepository.GetOwnerById(id);
                var owner = _mapper.Map<OwnerDTO>(ownerEntity);
                if (owner == null)
                {
                    return BadRequest(new { message = "Owner no encontrado", result = false });
                }
                return Ok(new { message = "Owner encontrado", result = true, data = owner });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Owner no encontrado", result = false });
            }
        }

        [HttpGet("Login")]
        public async Task<IActionResult> GetOwnerByLogin(string email, string password)
        {
            try
            {
                var ownerEntity = await _ownerRepository.GetOwnerByEmail(email, password);
                var owner = _mapper.Map<OwnerDTO>(ownerEntity);

                if (owner == null)
                {
                    return NotFound();
                }
                return Ok(new { message = "Owner encontrado", result = true, data = owner });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Owner no encontrado", result = false });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OwnerDTO ownerDto)
        {
            try
            {
                var owner= _mapper.Map<Owner>(ownerDto);
                await _ownerRepository.AddOwner(owner);

                owner = await _ownerRepository.GetOwnerById(owner.IdOwner);
                var ownerCreated = _mapper.Map<OwnerDTO>(owner);
                return Ok(new { message ="Owner creado correctamente", result = true, data = ownerCreated });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Owner no creado", result = false });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(OwnerDTO ownerDto)
        {
            try
            {
                var ownerModified = _mapper.Map<Owner>(ownerDto);
                await _ownerRepository.UpdateOwner(ownerModified);
                ownerModified = await _ownerRepository.GetOwnerById(ownerModified.IdOwner);
                var owner = _mapper.Map<OwnerDTO>(ownerModified);
                return Ok(new { message ="Owner actualizado correctamente" , result = true, data = owner });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Owner no actualizado", result = false });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ownerRepository.DeleteOwner(id);
                return Ok(new { respuesta = "Owner eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.InnerException.Message, result = false   });
            }
        }
        
    }
}
