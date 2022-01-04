
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DesafioInvestimentos.Models
{
    public class Acao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Codigo { get; set; }

        public string RazaoSocial { get; set; }

    }

}
