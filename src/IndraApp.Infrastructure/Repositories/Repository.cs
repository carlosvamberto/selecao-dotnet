using IndraApp.ApplicationCore.Interfaces.Repositories;
using IndraApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IndraApp.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly CursosContext _context;

        /// <summary>
        /// Construtor do repositório de cursos usando
        /// Injeção de Dependência do Contexto
        /// </summary>
        /// <param name="context">DbContext</param>
        public Repository(CursosContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adicionando um novo registro
        /// </summary>
        /// <param name="entity">Registro</param>
        /// <returns>Registro com o ID gerado na inclusão</returns>
        public virtual TEntity Add(TEntity entity)
        {
            _context
                .Set<TEntity>()
                .Add(entity);
            _context
                .SaveChanges();
            return entity;
        }

        /// <summary>
        /// Apagando um registro baseado no Id
        /// </summary>
        /// <param name="entity">Registro</param>
        public virtual void Delete(TEntity entity)
        {
            _context
                .Set<TEntity>()
                .Remove(entity);
            _context
                .SaveChanges();
        }

        /// <summary>
        /// Retornando Todos os Registros
        /// </summary>
        /// <returns>Lista de Registros</returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context
                .Set<TEntity>()
                .ToList();
        }

        /// <summary>
        /// Obtendo um Registro pelo Id
        /// </summary>
        /// <param name="id">Id do Registro</param>
        /// <returns>Registro</returns>
        public virtual TEntity GetById(int id)
        {
            return _context
                .Set<TEntity>()
                .Find(id);
        }

        /// <summary>
        /// Retornando um registro baseado em um critério (predicate)
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>Lista de Registros</returns>
        public virtual IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return _context
                .Set<TEntity>()
                .Where(predicate)
                .ToList();
        }        

        /// <summary>
        /// Atualiza os dados de um Registros baseado no Id
        /// </summary>
        /// <param name="entity">Dados do Registro</param>
        public virtual void Update(TEntity entity)
        {
            _context
                .Entry(entity)
                .State = EntityState.Modified;
            _context
                .SaveChanges();
        }
    }
}
