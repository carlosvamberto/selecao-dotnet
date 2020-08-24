using IndraApp.ApplicationCore.Entities;
using IndraApp.ApplicationCore.Interfaces.Repositories;
using IndraApp.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IndraApp.ApplicationCore.Services
{
    public class CursoService : IService<Curso>
    {
        IRepository<Curso> _cursoRepository;

        public CursoService(IRepository<Curso> cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public Curso Add(Curso entity)
        {
            // Validação dos campos obrigatórios
            string validText = "";

            if (string.IsNullOrWhiteSpace(entity.Nome))
                validText += Environment.NewLine + " - Nome é obrigatório";
            
            if (!string.IsNullOrWhiteSpace(validText))
                throw new Exception($"Erro de validação: {validText}");

            return _cursoRepository.Add(entity);
        }

        public void Delete(Curso entity) => _cursoRepository.Delete(entity);

        public IEnumerable<Curso> GetAll() => _cursoRepository.GetAll();

        public Curso GetById(int id) => _cursoRepository.GetById(id);

        public IEnumerable<Curso> Search(Expression<Func<Curso, bool>> predicate) =>
            _cursoRepository.Search(predicate);

        public void Update(Curso entity)
        {
            // Validação dos campos obrigatórios
            string validText = "";

            if (string.IsNullOrWhiteSpace(entity.Nome))
                validText += Environment.NewLine + " - Nome é obrigatório";

            if (!string.IsNullOrWhiteSpace(validText))
                throw new Exception($"Erro de validação: {validText}");

            _cursoRepository.Update(entity);
        }
    }
}
