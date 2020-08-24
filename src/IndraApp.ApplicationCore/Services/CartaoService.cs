using IndraApp.ApplicationCore.Entities;
using IndraApp.ApplicationCore.Interfaces.Repositories;
using IndraApp.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IndraApp.ApplicationCore.Services
{
    public class CartaoService : IService<Cartao>
    {
        IRepository<Cartao> _cartaoRepository;

        public CartaoService(IRepository<Cartao> cartaoRepository)
        {
            _cartaoRepository = cartaoRepository;
        }

        public Cartao Add(Cartao entity)
        {
            // Validação dos campos obrigatórios
            string validText = "";

            if (string.IsNullOrWhiteSpace(entity.Numero))
                validText += Environment.NewLine + " - Numero é obrigatório";
            if (string.IsNullOrWhiteSpace(entity.Validade))
                validText += Environment.NewLine + " - Validade é obrigatório";
            if (string.IsNullOrWhiteSpace(entity.Chave))
                validText += Environment.NewLine + " - Chave é obrigatório";

            if (!string.IsNullOrWhiteSpace(validText))
                throw new Exception($"Erro de validação: {validText}");

            return _cartaoRepository.Add(entity);
        }

        public void Delete(Cartao entity) => _cartaoRepository.Delete(entity);

        public IEnumerable<Cartao> GetAll() => _cartaoRepository.GetAll();

        public Cartao GetById(int id) => _cartaoRepository.GetById(id);

        public IEnumerable<Cartao> Search(Expression<Func<Cartao, bool>> predicate) =>
            _cartaoRepository.Search(predicate);

        public void Update(Cartao entity)
        {
            // Validação dos campos obrigatórios
            string validText = "";

            if (string.IsNullOrWhiteSpace(entity.Numero))
                validText += Environment.NewLine + " - Numero é obrigatório";
            if (string.IsNullOrWhiteSpace(entity.Validade))
                validText += Environment.NewLine + " - Validade é obrigatório";
            if (string.IsNullOrWhiteSpace(entity.Chave))
                validText += Environment.NewLine + " - Chave é obrigatório";

            if (!string.IsNullOrWhiteSpace(validText))
                throw new Exception($"Erro de validação: {validText}");

            _cartaoRepository.Update(entity);
        }
    }
}
