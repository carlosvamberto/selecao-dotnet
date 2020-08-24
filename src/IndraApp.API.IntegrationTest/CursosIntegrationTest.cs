using FluentAssertions;
using IndraApp.API.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IndraApp.API.IntegrationTest
{
    public class CursosIntegrationTest
    {
        [Fact]
        public async Task Curso_GetAll_Test()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/Curso");

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task Curso_GetById_Test()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/Curso/1");

                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task Curso_Create_Test()
        {
            using (var client = new TestClientProvider().Client)
            {

                var _curso = new StringContent(JsonConvert.SerializeObject( new CursoModel {
                    CursoId = 0, Nome = "Curso X1"
                }), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/api/Curso",_curso);

                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    }
}
