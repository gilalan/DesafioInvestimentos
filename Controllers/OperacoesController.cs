using System;
using System.Collections.Generic;
using DesafioInvestimentos.Models;
using DesafioInvestimentos.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioInvestimentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacoesController : ControllerBase
    {
        private readonly IOperacaoRepositorio _operacaoRepositorio;

        public OperacoesController(IOperacaoRepositorio operacaoRepositorio)
        {
            _operacaoRepositorio = operacaoRepositorio;
        }

        // GET: api/<OperacoesController>
        [HttpGet]
        public IEnumerable<Operacao> Get()
        {
            return _operacaoRepositorio.GetAll();
        }

        // GET api/<OperacoesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OperacoesController>
        [HttpPost]
        public IActionResult Post([FromBody] Operacao operacao)
        {
            try
            {
                Operacao operacaoToSave = new Operacao(operacao.AcaoId, operacao.Tipo, operacao.Quantidade, operacao.ValorAcao);
                _operacaoRepositorio.Save(operacaoToSave);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<OperacoesController>/5
        [HttpPut("{id}")]
        private void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<OperacoesController>/5
        [HttpDelete("{id}")]
        private void Delete(int id)
        {
            throw new NotImplementedException();
        }        
    }
}
