using FinalBackendWeb.Models;

namespace FinalBackendWeb.Interfaces
{
    public interface IPreguntaService
    {
        Task<IEnumerable<Pregunta>> ObtenerTodasLasPreguntasAsync();
        Task<Pregunta?> ObtenerPreguntaPorIdAsync(int id);
        Task<Pregunta> CrearPreguntaAsync(Pregunta pregunta);
        Task<IEnumerable<Pregunta>> ObtenerPorAsync(string estado);
    }
}