using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioInvestimentos.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioInvestimentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasAcoesController : ControllerBase
    {

        public ConsultasAcoesController()
        {
        }
        // GET: api/<ConsultasAcoesController>
        [HttpGet]
        private IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ConsultasAcoesController>/5
        [HttpGet("{id}")]
        public async Task<string> GetAsync(string id)
        {
            try
            {
                YahooResponse objectResponse = await AcaoConsultas.ObterCotacaoAsync(id);
                List<YahooQuote> results = objectResponse.QuoteResponse.Result;
                if (results.Count > 0)
                {
                    YahooQuote firstItem = results.First<YahooQuote>();
                    // não seria o ideal colocar camada de exibição no controler, mas coloquei para facilitar a visualização dos dados do desafio
                    string showQuote = String.Format("Moeda: {0}, Código da Ação: {1}, Empresa: {2}, Preço de Mercado: {3}",
                        firstItem.Currency, firstItem.Symbol, firstItem.DisplayName, firstItem.RegularMarketPrice);
                    return showQuote;
                }
                return "Não foi possível obter a cotação!";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<ConsultasAcoesController>
        [HttpPost]
        private void Post([FromBody] string value)
        {
        }

        // PUT api/<ConsultasAcoesController>/5
        [HttpPut("{id}")]
        private void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConsultasAcoesController>/5
        [HttpDelete("{id}")]
        private void Delete(int id)
        {
        }
    }
}
