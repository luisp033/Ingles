using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InglesModels;
using Microsoft.EntityFrameworkCore;

namespace InglesAPI.Models
{
    public class CapituloRepository : ICapituloRepository
    {
        private readonly AppDBContext appDBContext;

        public CapituloRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<Capitulo> AddCapitulo(Capitulo capitulo)
        {
            var result = await appDBContext.Capitulos.AddAsync(capitulo);
            await appDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Capitulo> GetCapitulo(int capituloId)
        {
            return await appDBContext.Capitulos
              .FirstOrDefaultAsync(e => e.CapituloId == capituloId);
        }

        public async Task<IEnumerable<Capitulo>> GetCapitulos()
        {
            return await appDBContext.Capitulos.ToListAsync();
        }

        public async Task<Capitulo> UpdateCapitulo(Capitulo capitulo)
        {
            var result = await appDBContext.Capitulos
                            .FirstOrDefaultAsync(e => e.CapituloId == capitulo.CapituloId);

            if (result != null)
            {
                result.CapituloNome = capitulo.CapituloNome;
                result.CapituloNumber = capitulo.CapituloNumber;
                result.CapituloTeoria = capitulo.CapituloTeoria;
                await appDBContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Capitulo> DeleteCapitulo(int capituloId)
        {
            var result = await appDBContext.Capitulos
                .FirstOrDefaultAsync(e => e.CapituloId == capituloId);
            if (result != null)
            {
                appDBContext.Capitulos.Remove(result);
                await appDBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
