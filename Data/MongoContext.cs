using MongoDB.Driver;

namespace DesafioInvestimentos.Data
{
    public class MongoContext : IDbContext
    {
        public string ConnectionString { get; set; }
        public string DataBase { get; set; }
        public IMongoDatabase Context
        {
            get
            {
                MongoUrl url = new MongoUrl(ConnectionString);
                MongoClient client = new MongoClient(url);
                return client.GetDatabase(this.DataBase);
            }
        }
    }
}
