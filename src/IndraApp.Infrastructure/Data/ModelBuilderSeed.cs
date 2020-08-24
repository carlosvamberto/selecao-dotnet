using IndraApp.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndraApp.Infrastructure.Data
{
    public static class ModelBuilderSeed
    {
        public static void Seed(this ModelBuilder modelBuild)
        {
            modelBuild.Entity<Curso>().HasData(
                new Curso { CursoId = 1, Nome = "Curso A"},
                new Curso { CursoId = 2, Nome = "Curso B"},
                new Curso { CursoId = 3, Nome = "Curso C" }
            );
        }
    }
}
