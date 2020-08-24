using IndraApp.ApplicationCore.Entities;
using IndraApp.ApplicationCore.Interfaces.Repositories;
using IndraApp.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;

namespace IndraApp.ApplicationCore.Services
{
    public class EstudanteService : IEstudanteService
    {
        IRepository<Estudante> _estudanteRepository;
        IRepository<Cartao> _cartaoRepository;

        public EstudanteService(IRepository<Estudante> estudanteRepository, IRepository<Cartao> cartaoRepository)
        {
            _estudanteRepository = estudanteRepository;
            _cartaoRepository = cartaoRepository;
        }

        public Estudante Add(Estudante entity)
        {

            // Validação dos campos obrigatórios
            string validText = "";

            if (string.IsNullOrWhiteSpace(entity.Email))
                validText += Environment.NewLine + " - Email é obrigatório";
            if (string.IsNullOrWhiteSpace(entity.Nome))
                validText += Environment.NewLine + " - Nome é obrigatório";

            if (!string.IsNullOrWhiteSpace(validText))
                throw new Exception($"Erro de validação: {validText}");

            return _estudanteRepository.Add(entity);
        }

        public void AddCard(int EstudanteId, Cartao cartao)
        {
            // Validação dos campos obrigatórios
            string validText = "";

            if (string.IsNullOrWhiteSpace(cartao.Numero))
                validText += Environment.NewLine + " - Número do Cartão é obrigatório";
            if (string.IsNullOrWhiteSpace(cartao.Validade))
                validText += Environment.NewLine + " - Validade do Cartão é obrigatório";
            if (string.IsNullOrWhiteSpace(cartao.Chave))
                validText += Environment.NewLine + " - Chave do Cartão é obrigatório";

            if (!string.IsNullOrWhiteSpace(validText))
                throw new Exception($"Erro de validação: {validText}");

            // Obtendo o estudande para verificar se já existe cartão vinculado
            // E para fazer Update depois que Adicionar o cartão
            var _estudante = _estudanteRepository.GetById(EstudanteId);
            
            if (_estudante == null)
                throw new Exception("Estudante não encontrado.");

            // Caso haja um cartão anterior, ele será removido antes de incluir outro
            if (_estudante.CartaoId != null && _estudante.CartaoId > 0)
            {
                _cartaoRepository.Delete(_cartaoRepository.GetById(_estudante.CartaoId.Value));
            }

            var _cartao = _cartaoRepository.Add(cartao);

            _estudante.CartaoId = _cartao.CartaoId;

            _estudanteRepository.Update(_estudante);
        }

        public void Delete(Estudante entity) => _estudanteRepository.Delete(entity);

        public IEnumerable<Estudante> GetAll() => _estudanteRepository.GetAll();

        public Estudante GetById(int id) => _estudanteRepository.GetById(id);

        public IEnumerable<Estudante> Search(Expression<Func<Estudante, bool>> predicate) => 
            _estudanteRepository.Search(predicate);        

        public void Update(Estudante entity)
        {
            // Validação dos campos obrigatórios
            string validText = "";

            if (string.IsNullOrWhiteSpace(entity.Email))
                validText += Environment.NewLine + " - Email é obrigatório";
            if (string.IsNullOrWhiteSpace(entity.Nome))
                validText += Environment.NewLine + " - Nome é obrigatório";

            if (!string.IsNullOrWhiteSpace(validText))
                throw new Exception($"Erro de validação: {validText}");

            _estudanteRepository.Update(entity);
        }
    }
}
