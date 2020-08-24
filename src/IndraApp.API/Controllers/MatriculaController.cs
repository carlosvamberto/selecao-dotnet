using AutoMapper;
using IndraApp.API.Models;
using IndraApp.ApplicationCore.Entities;
using IndraApp.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace IndraApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        IService<Matricula> _matriculaService;        
        IMapper _mapper;

        public MatriculaController(
            IService<Matricula> matriculaService,            
            IMapper mapper)
        {
            _matriculaService = matriculaService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var _matricula = _matriculaService
                    .GetById(id);

                if (_matricula == null)
                    return NotFound();

                var _matriculaModel = _mapper.Map<MatriculaModel>(_matricula);

                return Ok(_matriculaModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("byEstudanteId/{estudanteId}")]
        public IActionResult GetByEstudanteId(int estudanteId)
        {
            try
            {
                var _matriculas = _matriculaService
                    .Search(m => m.EstudanteId == estudanteId)
                    .AsEnumerable();

                if (_matriculas == null || !_matriculas.Any())
                    return NotFound();

                var _matriculaModel = _mapper.Map<MatriculaModel[]>(_matriculas);

                return Ok(_matriculaModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] MatriculaModel _matriculaModel)
        {
            try
            {
                var _matricula = _mapper.Map<Matricula>(_matriculaModel);
                _matricula = _matriculaService.Add(_matricula);
                return Ok(_matricula);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] MatriculaModel _matriculaModel)
        {
            try
            {
                var _matricula = _mapper.Map<Matricula>(_matriculaModel);
                _matriculaService.Update(_matricula);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var _matricula = _matriculaService
                    .GetById(id);

                if (_matricula == null)
                    return NotFound();

                
                _matriculaService.Delete(_matricula);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
