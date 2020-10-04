using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InglesModels;
using Microsoft.EntityFrameworkCore;

namespace InglesAPI.Models
{
    public class QuestaoRepository : IQuestaoRepository
    {

        private readonly AppDBContext appDBContext;

        public QuestaoRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<Questao> AddQuestao(Questao questao)
        {
            var result = await appDBContext.Questoes.AddAsync(questao);
            await appDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Questao> DeleteQuestao(int questaoId)
        {
            var result = await appDBContext.Questoes
                .FirstOrDefaultAsync(e => e.QuestaoId == questaoId);
            if (result != null)
            {
                appDBContext.Questoes.Remove(result);
                await appDBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Questao> GetQuestao(int questaoId)
        {
            return await appDBContext.Questoes
                             .Include(r => r.Exercicio)
                             .ThenInclude(c => c.Capitulo)
                             .FirstOrDefaultAsync(e => e.QuestaoId == questaoId);
        }

        public async Task<IEnumerable<Questao>> GetQuestoesByExercicio(int id)
        {
            IQueryable<Questao> query = appDBContext.Questoes;
            query = query.Where(e => e.ExercicioId == id);
            return await query.ToListAsync();
        }

        public async Task<Questao> UpdateQuestao(Questao questao)
        {
            var result = await appDBContext.Questoes
                            .FirstOrDefaultAsync(e => e.QuestaoId == questao.QuestaoId);

            if (result != null)
            {
                result.QuestaoNumber = questao.QuestaoNumber;
                result.QuestaoTexto = questao.QuestaoTexto;
                result.ExercicioId = questao.ExercicioId;

                await appDBContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
