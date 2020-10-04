using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InglesModels;

namespace InglesAPI.Models
{
    public interface IQuestaoRepository
    {
        Task<IEnumerable<Questao>> GetQuestoesByExercicio(int id);
        Task<Questao> GetQuestao(int questaoId);
        Task<Questao> AddQuestao(Questao questao);
        Task<Questao> UpdateQuestao(Questao questao);
        Task<Questao> DeleteQuestao(int questaoId);
    }
}
