using IndraApp.ApplicationCore.Entities;

namespace IndraApp.ApplicationCore.Interfaces.Services
{
    public interface IEstudanteService : IService<Estudante>
    {
        void AddCard(int EstudanteId, Cartao cartao);
    }
}
