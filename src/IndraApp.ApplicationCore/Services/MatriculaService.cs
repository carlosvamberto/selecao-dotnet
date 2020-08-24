using IndraApp.ApplicationCore.Entities;
using IndraApp.ApplicationCore.Interfaces.Repositories;
using IndraApp.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IndraApp.ApplicationCore.Services
{
    public class MatriculaService : IService<Matricula>
    {
        IRepository<Matricula> _matriculaRepository;
        IRepository<Estudante> _estudanteRepository;
        IRepository<Pagamento> _pagamentoRepository;

        public MatriculaService(
            IRepository<Matricula> matriculaRepository,
            IRepository<Estudante> estudanteRepository,
            IRepository<Pagamento> pagamentoRepository
            )
        {
            _matriculaRepository = matriculaRepository;
            _estudanteRepository = estudanteRepository;
            _pagamentoRepository = pagamentoRepository;
        }

        public Matricula Add(Matricula entity)
        {
            // Validação dos campos obrigatórios
            string validText = "";

            if (entity.EstudanteId == 0)
                validText += Environment.NewLine + " - EstudanteId é obrigatório";
            if (entity.CursoId == 0)
                validText += Environment.NewLine + " - CursoId é obrigatório";

            if (!string.IsNullOrWhiteSpace(validText))
                throw new Exception($"Erro de validação: {validText}");

            // Verificando se o Estudante Existe
            var _estudante = _estudanteRepository.GetById(entity.EstudanteId);
            if (_estudante == null) throw new Exception("Estudante não existe");

            // Verificando se o Estudante tem algum pagamento feito
            var _pagamentos = _pagamentoRepository
                .Search(p => p.EstudanteId == entity.EstudanteId && p.Pago == true)
                .AsEnumerable();
            if (_pagamentos == null || !_pagamentos.Any()) throw new Exception("Não existe pagamentos realizados pelo Estudante");

            return _matriculaRepository.Add(entity);
        }

        public void Delete(Matricula entity) => _matriculaRepository.Delete(entity);

        public IEnumerable<Matricula> GetAll() => _matriculaRepository.GetAll();

        public Matricula GetById(int id) => _matriculaRepository.GetById(id);

        public IEnumerable<Matricula> Search(Expression<Func<Matricula, bool>> predicate) =>
            _matriculaRepository.Search(predicate);

        public void Update(Matricula entity)
        {
            // Validação dos campos obrigatórios
            string validText = "";

            if (entity.EstudanteId == 0)
                validText += Environment.NewLine + " - EstudanteId é obrigatório";
            if (entity.CursoId == 0)
                validText += Environment.NewLine + " - CursoId é obrigatório";

            if (!string.IsNullOrWhiteSpace(validText))
                throw new Exception($"Erro de validação: {validText}");

            // Verificando se o Estudante Existe
            var _estudante = _estudanteRepository.GetById(entity.EstudanteId);
            if (_estudante == null) throw new Exception("Estudante não existe");

            // Verificando se o Estudante tem algum pagamento feito
            var _pagamentos = _pagamentoRepository
                .Search(p => p.EstudanteId == entity.EstudanteId && p.Pago == true)
                .AsEnumerable();
            if (_pagamentos == null || !_pagamentos.Any()) throw new Exception("Não existe pagamentos realizados pelo Estudante");

            _matriculaRepository.Update(entity);
        }
    }
}
