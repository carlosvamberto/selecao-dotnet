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
    public class EstudanteController : ControllerBase
    {
        // Objetos vindos da Injeção de Dependência 
        // que serão usados no controller
        IEstudanteService _estudanteService;
        //IService<Pagamento> _pagamentoService;
        IService<Cartao> _cartaoService;
        
        IMapper _mapper;

        public EstudanteController(
            IEstudanteService estudanteService, 
            IService<Cartao> cartaoService,
            //IService<Pagamento> pagamentoService,
            IMapper mapper)
        {
            _estudanteService = estudanteService;
            _cartaoService = cartaoService;
            //_pagamentoService = pagamentoService,
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var _lista = _estudanteService
                    .GetAll()
                    .AsEnumerable();

                if (_lista == null || !_lista.Any())
                    return NotFound();

                var _model = _mapper.Map<EstudanteModel[]>(_lista);

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
                var _estudante = _estudanteService
                    .GetById(id);

                if (_estudante == null)
                    return NotFound();

                var _estudanteModel = _mapper.Map<EstudanteModel>(_estudante);

                return Ok(_estudanteModel);
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
                var _lista = _estudanteService
                        .Search(e => e.Nome.Contains(filter))
                        .AsEnumerable();

                if (_lista == null || !_lista.Any())
                    return NotFound();

                var _model = _mapper.Map<CartaoModel[]>(_lista);

                return Ok(_model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Create([FromBody] EstudanteModel _estudanteModel)
        {
            try
            {
                Estudante _estudante = _mapper.Map<Estudante>(_estudanteModel);
                _estudante = _estudanteService.Add(_estudante);
                return Ok(_estudante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] EstudanteModel _estudanteModel)
        {
            try
            {
                Estudante _estudante = _mapper.Map<Estudante>(_estudanteModel);
                _estudanteService.Update(_estudante);
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
                Estudante _estudante = _estudanteService
                    .GetById(id);

                if (_estudante == null)
                    return NotFound();

                if (_estudante.CartaoId != null && _estudante.CartaoId > 0)
                    _cartaoService.Delete(_cartaoService.GetById(_estudante.CartaoId.Value));

                _estudanteService.Delete(_estudante);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
                
    }
}
