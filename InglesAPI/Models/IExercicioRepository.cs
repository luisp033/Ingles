using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InglesModels;

namespace InglesAPI.Models
{
    public interface IExercicioRepository
    {
        Task<IEnumerable<Exercicio>> GetExerciciosByCapitulo(int capituloId);
        Task<Exercicio> GetExercicio(int exercicioId);
        Task<Exercicio> AddExercicio(Exercicio exercicio);
        Task<Exercicio> UpdateExercicio(Exercicio exercicio);
        Task<Exercicio> DeleteExercicio(int exercicioId);

    }
}
