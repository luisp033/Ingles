using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InglesModels;

namespace InglesWeb.Services
{
    public interface IExercicioService
    {

        Task<IEnumerable<Exercicio>> GetExerciciosByCapitulo(int id);

        Task<Exercicio> GetExercicio(int id);

        Task<Exercicio> UpdateExercicio(Exercicio updatedExercicio);

        Task<Exercicio> CreateExercicio(Exercicio newExercicio);

        Task DeleteExercicio(int id);

    }
}
