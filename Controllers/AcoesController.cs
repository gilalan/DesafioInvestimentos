﻿using System;
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
        public IEnumerable<Acao> Get()
        {
            try
            {
                return _acaoRepositorio.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<AcoesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                return "value";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<AcoesController>
        [HttpPost]
        public IActionResult Post([FromBody] Acao acao)
        {
            try
            {
                _acaoRepositorio.Save(acao);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<AcoesController>/5
        [HttpPut("{id}")]
        private void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<AcoesController>/5
        [HttpDelete("{id}")]
        private void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
