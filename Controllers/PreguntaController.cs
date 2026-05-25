using FinalBackendWeb.Interface;
using FinalBackendWeb.Interfaces;
using FinalBackendWeb.Models;
using FinalBackendWeb.Services;
using Microsoft.AspNetCore.Mvc;


namespace FinalBackendWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PreguntaController : ControllerBase

    {

        private readonly IPreguntaService _PreguntaService;

        public PreguntaController(IPreguntaService preguntaService)
        {
            _PreguntaService = preguntaService;
        }


        [HttpPost]
        public async Task<IActionResult> CrearPregunta([FromBody] Pregunta pregunta)
        {
            if (pregunta == null) return BadRequest("No puede ser vacio la pregunta");

            var nuevaPregunta = await _PreguntaService.CrearPreguntaAsync(pregunta);

            return Ok(nuevaPregunta);
        }

        [HttpGet("Estado")]

        public async Task<IActionResult> GetByEstado([FromQuery] string estado)
        {
            if (estado == null) return BadRequest("El parametro el obligatorio");


            var preguntas = await _PreguntaService.ObtenerPorAsync(estado);
            return Ok(preguntas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pregunta = await _PreguntaService.ObtenerPreguntaPorIdAsync(id);
            if (pregunta == null)
            {
                return NotFound(new { mensaje = $"La pregunta con ID {id} no existe." });
            }
            return Ok(pregunta);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] Pregunta pregunta)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevaPregunta = await _PreguntaService.CrearPreguntaAsync(pregunta);
            return CreatedAtAction(nameof(GetById), new { id = nuevaPregunta.id_Pregunta }, nuevaPregunta);
        }



    }
}
