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
    public class CartaoController : ControllerBase
    {
        // Objetos vindos da Injeção de Dependência 
        // que serão usados no controller
        IService<Cartao> _cartaoService;
        IMapper _mapper;

        public CartaoController(IService<Cartao> cartaoService, IMapper mapper)
        {
            _cartaoService = cartaoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var _lista = _cartaoService
                    .GetAll()
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var _curso = _cartaoService
                    .GetById(id);

                if (_curso == null)
                    return NotFound();

                var _cartaoModel = _mapper.Map<CartaoModel>(_curso);

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
                var _lista = _cartaoService
                        .Search(e => e.Numero == filter)
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
        public IActionResult Create([FromBody] CartaoModel _cartaoModel)
        {
            try
            {
                var _cartao = _mapper.Map<Cartao>(_cartaoModel);
                _cartao = _cartaoService.Add(_cartao);
                return Ok(_cartao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] CartaoModel _cartaoModel)
        {
            try
            {
                var _cartao = _mapper.Map<Cartao>(_cartaoModel);
                _cartaoService.Update(_cartao);
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
                var _cartao = _cartaoService
                    .GetById(id);

                if (_cartao == null)
                    return NotFound();

                _cartaoService.Delete(_cartao);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
