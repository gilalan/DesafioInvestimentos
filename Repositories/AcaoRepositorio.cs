using DesafioInvestimentos.Data;
using DesafioInvestimentos.Models;
using DesafioInvestimentos.Repositories.interfaces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DesafioInvestimentos.Repositories
{
    public class AcaoRepositorio : IAcaoRepositorio
    {
        private IDbContext DbContext { get; set; }
        private IMongoCollection<Acao> Collection { get; set; }

        public AcaoRepositorio(IDbContext context)
        {
            this.DbContext = context;
            this.Collection = context.Context.GetCollection<Acao>("Acoes");
        }

        //public IEnumerable<Acao> GetAll() 
        //{
        //    this.Collection.Database.GetCollection();
        //}

        public void Save(Acao acao)
        {
            this.Collection.InsertOne(acao);
        }
    }
}
