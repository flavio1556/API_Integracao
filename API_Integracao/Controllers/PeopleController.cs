using API_Integracao.Entites;
using API_Integracao.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using API_Integracao.DTO;
using API_Integracao.Models;

namespace API_Integracao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPerson _service;

        public PeopleController(IPerson service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _service.GetAll();
                return Ok(result);
            }catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var result = await _service.GetById(id);
                if(result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            try
            {
                if (person == null) return BadRequest("invalid input");
                var result = await _service.Post(person);                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Person person)
        {
            try
            {
                if (person == null) return BadRequest("invalid input");
                var result =  await _service.Put(person);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                if (id == 0) return BadRequest("invalid input");
                var result = await _service.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpDelete()]
        [Route("DeleteByObject")]
        public async Task<IActionResult> Delete([FromBody] PersonDeleteModels person)
        {
            try
            {
                if (person == null) return BadRequest("invalid input");
                var result = await _service.Delete(person);
                if(!result) return NotFound();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
