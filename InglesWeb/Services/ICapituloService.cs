using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InglesModels;

namespace InglesWeb.Services
{
    public interface ICapituloService
    {
        Task<IEnumerable<Capitulo>> GetCapitulos();

        Task<Capitulo> GetCapitulo(int id);

        Task<Capitulo> UpdateCapitulo(Capitulo updatedCapitulo);

        Task<Capitulo> CreateCapitulo(Capitulo newCapitulo);

        Task DeleteCapitulo(int id);
    }

}

