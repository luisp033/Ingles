using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InglesModels;
using Microsoft.EntityFrameworkCore;

namespace InglesAPI.Models
{
    public class ExercicioRepository : IExercicioRepository
    {

        private readonly AppDBContext appDBContext;

        public ExercicioRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<Exercicio> AddExercicio(Exercicio exercicio)
        {
            var result = await appDBContext.Exercicios.AddAsync(exercicio);
            await appDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Exercicio> DeleteExercicio(int exercicioId)
        {
            var result = await appDBContext.Exercicios
                .FirstOrDefaultAsync(e => e.ExercicioId == exercicioId);
            if (result != null)
            {
                appDBContext.Exercicios.Remove(result);
                await appDBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Exercicio> GetExercicio(int exercicioId)
        {
            return await appDBContext.Exercicios
                        .Include(r => r.Capitulo)
                        .FirstOrDefaultAsync(e => e.ExercicioId == exercicioId);
        }

        public async Task<IEnumerable<Exercicio>> GetExerciciosByCapitulo(int capituloId)
        {
            IQueryable<Exercicio> query = appDBContext.Exercicios;
            query = query.Where(e => e.CapituloId == capituloId);
            return await query.ToListAsync();
        }

        public async Task<Exercicio> UpdateExercicio(Exercicio exercicio)
        {
            var result = await appDBContext.Exercicios
                            .FirstOrDefaultAsync(e => e.ExercicioId == exercicio.ExercicioId);

            if (result != null)
            {
                result.ExercicioNumber = exercicio.ExercicioNumber;
                result.ExercicioTexto = exercicio.ExercicioTexto;
                result.ExercicioImagePath = exercicio.ExercicioImagePath;
                result.CapituloId = exercicio.CapituloId;

                await appDBContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
