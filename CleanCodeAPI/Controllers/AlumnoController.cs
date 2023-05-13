using CleanCodeAPI.Data.Repositories;
using CleanCodeAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoRepository _alumnoRepository;

        public AlumnoController(IAlumnoRepository alumnoRepository)
        {
            _alumnoRepository = alumnoRepository;
        }
        [HttpGet]
        public async Task<IActionResult>GetAllAlumnos()
        {
            return Ok(await _alumnoRepository.GetAllAlumnos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlumnoDetails(int ID)
        {
            return Ok(await _alumnoRepository.GetDetails(ID));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAlumno([FromBody] Alumno alumno)
        {
            if (alumno == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest();
            var created = await _alumnoRepository.InsertAlumno(alumno);
            return Created("created", created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAlumno([FromBody] Alumno alumno)
        {
            if (alumno == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();
            var created = await _alumnoRepository.UpdateAlumno(alumno);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult>  DeleteAlumno(int ID)
        {
            await _alumnoRepository.DeleteAlumno(new Alumno { id = ID });
            return NoContent();
        }
    }
}
