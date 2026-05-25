
using FinalBackendWeb.Interface;
using FinalBackendWeb.Interfaces;
using FinalBackendWeb.Models;
using FinalBackendWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace FinalBackendWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RespuestaController : ControllerBase
    {
        private readonly IRespuestaSerivce _respuestaService;


        public RespuestaController(IRespuestaSerivce respuestaService)
        {
            _respuestaService = respuestaService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearRespuesta([FromBody] Respuesta respuesta)
        {
            if (respuesta == null) return BadRequest("Añada una respuesta");

            try
            {

                var nuevaRespuesta = await _respuestaService.CrearRespuestaAsync(respuesta);


                return Ok(new
                {
                    id = nuevaRespuesta.Id,
                    contenido = nuevaRespuesta.Contenido,
                    PreguntaId = nuevaRespuesta.PreguntaId,

                });


            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");

            }

        }
            
        }
    }