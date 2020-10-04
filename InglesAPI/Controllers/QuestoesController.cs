using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InglesModels;
using InglesAPI.Models;

namespace InglesAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class QuestoesController : ControllerBase
    {
        private readonly IQuestaoRepository questaoRepository;
        public QuestoesController(IQuestaoRepository questaoRepository)
        {
            this.questaoRepository = questaoRepository;
        }

        //// GET: api/Questoes/exercicio/1
        [HttpGet("{exercicio}/{id}")]
        public async Task<ActionResult> GetQuestoesByExercicio(int id)
        {
            try
            {
                var result = await questaoRepository.GetQuestoesByExercicio(id);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET api/Questoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Questao>> GetQuestao(int id)
        {
            try
            {
                var result = await questaoRepository.GetQuestao(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST api/Questoes
        [HttpPost]
        public async Task<ActionResult<Questao>> CreateQuestao(Questao questao)
        {
            try
            {
                if (questao == null)
                    return BadRequest();

                var created = await questaoRepository.AddQuestao(questao);

                return CreatedAtAction(nameof(GetQuestao), new { id = created.QuestaoId }, created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }


        // PUT api/Questoes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Questao>> Put(Questao questao)
        {
            try
            {
                var ToUpdate = await questaoRepository.GetQuestao(questao.QuestaoId);

                if (ToUpdate == null)
                    return NotFound($"Questao with Id = {questao.QuestaoId} not found");

                return await questaoRepository.UpdateQuestao(questao);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }


        // DELETE api/Questoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Questao>> DeleteQuestao(int id)
        {
            try
            {
                var ToDelete = await questaoRepository.GetQuestao(id);

                if (ToDelete == null)
                {
                    return NotFound($"Questao with Id = {id} not found");
                }
                return await questaoRepository.DeleteQuestao(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }

        }

    }
}
