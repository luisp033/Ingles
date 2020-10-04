using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InglesModels;

namespace InglesAPI.Models
{
    public interface ICapituloRepository
    {
        Task<IEnumerable<Capitulo>> GetCapitulos();
        Task<Capitulo> GetCapitulo(int capituloId);
        Task<Capitulo> AddCapitulo(Capitulo capitulo);
        Task<Capitulo> UpdateCapitulo(Capitulo capitulo);
        Task<Capitulo> DeleteCapitulo(int capituloId);
    }
}
