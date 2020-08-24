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
    public class PagamentoController : ControllerBase
    {
        IService<Pagamento> _pagamentoService;
        IMapper _mapper;

        public PagamentoController(IService<Pagamento> pagamentoService, IMapper mapper)
        {
            _pagamentoService = pagamentoService;
            _mapper = mapper;

        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var _lista = _pagamentoService
                    .GetAll()
                    .AsEnumerable();

                if (_lista == null || !_lista.Any())
                    return NotFound();

                var _model = _mapper.Map<PagamentoModel[]>(_lista);

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
                var _curso = _pagamentoService
                    .GetById(id);

                if (_curso == null)
                    return NotFound();

                var _cartaoModel = _mapper.Map<PagamentoModel>(_curso);

                return Ok(_cartaoModel);
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
                var _lista = _pagamentoService
                        .Search(e => e.Estudante.Nome == filter)
                        .AsEnumerable();

                if (_lista == null || !_lista.Any())
                    return NotFound();

                var _model = _mapper.Map<PagamentoModel[]>(_lista);

                return Ok(_model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Create([FromBody] PagamentoModel _pagamentoModel)
        {
            try
            {
                var _pagamento = _mapper.Map<Pagamento>(_pagamentoModel);
                _pagamento = _pagamentoService.Add(_pagamento);
                return Ok(_pagamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] PagamentoModel _pagamentoModel)
        {
            try
            {
                var _pagamento = _mapper.Map<Pagamento>(_pagamentoModel);
                _pagamentoService.Update(_pagamento);
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
                var _pagamento = _pagamentoService
                    .GetById(id);

                if (_pagamento == null)
                    return NotFound();

                _pagamentoService.Delete(_pagamento);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
