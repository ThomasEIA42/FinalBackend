using FinalBackendWeb.Models;

namespace FinalBackendWeb.Interface
{
    public interface IRespuestaSerivce
    {
        Task<IEnumerable<Respuesta>> ObtenerRespuestasPorPreguntaAsync(int preguntaId);
        Task<Respuesta> CrearRespuestaAsync(Respuesta respuesta);

    }
}
