using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioInvestimentos.Models;
using DesafioInvestimentos.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioInvestimentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcoesController : ControllerBase
    {
        private readonly IAcaoRepositorio _acaoRepositorio;
        public AcoesController(IAcaoRepositorio acaoRepositorio)
        {
            _acaoRepositorio = acaoRepositorio;
        }
        // GET: api/<AcoesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AcoesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AcoesController>
        [HttpPost]
        public IActionResult Post([FromBody] Acao acao)
        {
            _acaoRepositorio.Save(acao);
            return Ok();
        }

        // PUT api/<AcoesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AcoesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
