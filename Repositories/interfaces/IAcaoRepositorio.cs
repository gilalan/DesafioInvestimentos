using DesafioInvestimentos.Models;
using System.Collections.Generic;

namespace DesafioInvestimentos.Repositories.interfaces
{
    public interface IAcaoRepositorio
    {
        void Save(Acao acao);
        IEnumerable<Acao> GetAll();
    }
}
