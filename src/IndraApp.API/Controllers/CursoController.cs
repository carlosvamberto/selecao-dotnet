using System;
using System.Linq;
using AutoMapper;
using IndraApp.API.Models;
using IndraApp.ApplicationCore.Entities;
using IndraApp.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace IndraApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        IService<Curso> _cursoService;
        IMapper _mapper;

        public CursoController(IService<Curso> cursoService, IMapper mapper)
        {
            _cursoService = cursoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var _lista = _cursoService
                    .GetAll()
                    .AsEnumerable();

                if (_lista == null || !_lista.Any())
                    return NotFound();

                var _model = _mapper.Map<CursoModel[]>(_lista);

                return Ok(_model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var _curso = _cursoService
                    .GetById(id);

                if (_curso == null)
                    return NotFound();

                var _model = _mapper.Map<CursoModel>(_curso);

                return Ok(_model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search/{filter}")]
        public IActionResult Search(string filter)
        {
            try
            {
                var _lista = _cursoService
                        .Search(e => e.Nome.Contains(filter))
                        .AsEnumerable();

                if (_lista == null || !_lista.Any())
                    return NotFound();

                var _model = _mapper.Map<CursoModel[]>(_lista);

                return Ok(_model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Create([FromBody] CursoModel _cursoModel)
        {
            try
            {
                var _curso = _mapper.Map<Curso>(_cursoModel);
                _curso = _cursoService.Add(_curso);
                return Ok(_curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] CursoModel _cursoModel)
        {
            try
            {
                var _curso = _mapper.Map<Curso>(_cursoModel);
                _cursoService.Update(_curso);
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
                var _curso = _cursoService
                    .GetById(id);

                if (_curso == null)
                    return NotFound();

                _cursoService.Delete(_curso);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
