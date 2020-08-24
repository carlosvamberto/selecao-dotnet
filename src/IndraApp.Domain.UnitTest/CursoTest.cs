using IndraApp.ApplicationCore.Entities;
using IndraApp.ApplicationCore.Services;
using IndraApp.Infrastructure.Data;
using IndraApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Xunit;

namespace IndraApp.Domain.UnitTest
{
    public class CursoTest
    {
        private static CursoService MontaServico()
        {
            var _opt = new DbContextOptionsBuilder<CursosContext>();
            _opt.UseSqlServer("Server = localhost; Database = CursosDB; Trusted_Connection = True");

            var _contexto = new CursosContext(_opt.Options);
            var _cursoRepository = new Repository<Curso>(_contexto);
            CursoService _cursoService = new CursoService(_cursoRepository);
            return _cursoService;
        }

        [Fact]
        public void Curso_GetAll_Test()
        {
            CursoService _cursoService = MontaServico();

            var _lista = _cursoService.GetAll();

            Assert.True(_lista.Any());
        }        

        [Fact]
        public void Curso_GetById_Test()
        {            
            CursoService _cursoService = MontaServico();

            var _curso0 = _cursoService.GetById(0);
            var _curso1 = _cursoService.GetById(1);

            Assert.True(_curso0 == null);
            Assert.True(_curso1 != null);
        }
    }
}
