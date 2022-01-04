using System;
using DesafioInvestimentos.Models;
using System.Collections.Generic;

namespace DesafioInvestimentos.Repositories.interfaces
{
    public interface IOperacaoRepositorio
    {
        void Save(Operacao operacao);
        IEnumerable<Operacao> GetAll();
    }
}
