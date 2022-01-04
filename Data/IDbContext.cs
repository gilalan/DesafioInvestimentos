using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioInvestimentos.Data
{
    public interface IDbContext
    {
        IMongoDatabase Context { get; }
    }
}
