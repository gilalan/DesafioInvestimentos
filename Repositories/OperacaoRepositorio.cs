using DesafioInvestimentos.Data;
using DesafioInvestimentos.Models;
using DesafioInvestimentos.Repositories.interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioInvestimentos.Repositories
{
    public class OperacaoRepositorio : IOperacaoRepositorio
    {
        private IDbContext DbContext { get; set; }
        private IMongoCollection<Operacao> Collection { get; set; }

        public OperacaoRepositorio(IDbContext context)
        {
            this.DbContext = context;
            this.Collection = context.Context.GetCollection<Operacao>("Operacoes");
        }

        public IEnumerable<Operacao> GetAll()
        {
            var result = this.Collection.Find(FilterDefinition<Operacao>.Empty);
            if (result == null)
            {
                return new List<Operacao>();
            }

            return result.ToList();
        }

        public void Save(Operacao operacao)
        {
            this.Collection.InsertOne(operacao);
        }
    }
}
