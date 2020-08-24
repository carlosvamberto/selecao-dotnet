using IndraApp.ApplicationCore.Entities;
using IndraApp.ApplicationCore.Interfaces.Repositories;
using IndraApp.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IndraApp.ApplicationCore.Services
{
    public class PagamentoService : IService<Pagamento>
    {
        IRepository<Pagamento> _pagamentoRepository;
        IRepository<Estudante> _estudanteRepository;

        public PagamentoService(IRepository<Pagamento> pagamentoRepository, IRepository<Estudante> estudanteRepository)
        {
            _pagamentoRepository = pagamentoRepository;
            _estudanteRepository = estudanteRepository;
        }

        public Pagamento Add(Pagamento entity)
        {
            // Validação dos campos obrigatórios
            string validText = "";

            if (entity.EstudanteId == 0)
                validText += Environment.NewLine + " - EstudanteId é obrigatório";
            if ( entity.Vencimento == DateTime.MinValue)
                validText += Environment.NewLine + " - Vencimento é obrigatório";

            if (!string.IsNullOrWhiteSpace(validText))
                throw new Exception($"Erro de validação: {validText}");

            var _estudante = _estudanteRepository.GetById(entity.EstudanteId);

            entity.Estudante = _estudante ?? throw new Exception("Estudante não existe");

            return _pagamentoRepository.Add(entity);
        }

        public void Delete(Pagamento entity) => _pagamentoRepository.Delete(entity);

        public IEnumerable<Pagamento> GetAll() => _pagamentoRepository.GetAll();

        public Pagamento GetById(int id) => _pagamentoRepository.GetById(id);

        public IEnumerable<Pagamento> Search(Expression<Func<Pagamento, bool>> predicate) =>
            _pagamentoRepository.Search(predicate);

        public void Update(Pagamento entity)
        {
            // Validação dos campos obrigatórios
            string validText = "";

            if (entity.EstudanteId == 0)
                validText += Environment.NewLine + " - EstudanteId é obrigatório";
            if (entity.Vencimento == DateTime.MinValue)
                validText += Environment.NewLine + " - Vencimento é obrigatório";

            if (!string.IsNullOrWhiteSpace(validText))
                throw new Exception($"Erro de validação: {validText}");

            var _estudante = _estudanteRepository.GetById(entity.EstudanteId);

            if (_estudante == null) throw new Exception("Estudante não existe");

            _pagamentoRepository.Update(entity);
        }
    }
}
