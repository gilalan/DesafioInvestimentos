using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DesafioInvestimentos.Models
{
    public class Operacao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string AcaoId { get; set; }

        public int Quantidade { get; set; }

        public double ValorAcao { get; set; }

        public string Tipo { get; set; }

        public DateTime Data { get; private set; }
        public double ValorTotal { get; private set; }

        private const double TaxaCusto = 5;
        private const double TaxaEmolumento = 0.000325; //0,0325%

        public Operacao()
        {

        }     

        public Operacao(string acaoId, string tipo, int quantidade, double valorAcao)
        {
            AcaoId = acaoId;
            Tipo = tipo;
            Data = DateTime.Now;
            Quantidade = quantidade;
            ValorAcao = valorAcao;
            ValorTotal = CalcularValorTotal(quantidade, valorAcao);
        }

        private double CalcularValorTotal(int quantidade, double valorAcao)
        {
            double valorOperacao = quantidade * valorAcao;
            double custoOperacao = TaxaCusto + (TaxaEmolumento * valorOperacao);
            return (valorOperacao + custoOperacao);
        }
    }
}
