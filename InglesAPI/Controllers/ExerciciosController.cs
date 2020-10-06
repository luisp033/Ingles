using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InglesModels;
using Microsoft.AspNetCore.Http;
using InglesAPI.Models;


namespace InglesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciciosController : ControllerBase
    {

        private readonly IExercicioRepository exercicioRepository;

        public ExerciciosController(IExercicioRepository exercicioRepository)
        {
            this.exercicioRepository = exercicioRepository;
        }


        //// GET: api/Exercicios/capitulo/1
        [HttpGet("{capitulo}/{id}")]
        public async Task<ActionResult> GetExercicioByCapitulo(int id)
        {
            try
            {
                var result = await exercicioRepository.GetExerciciosByCapitulo(id);

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

        // GET api/Exercicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercicio>> GetExercicio(int id)
        {
            try
            {
                var result = await exercicioRepository.GetExercicio(id);

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

        // POST api/Exercicios
        [HttpPost]
        public async Task<ActionResult<Exercicio>> CreateExercicio(Exercicio exercicio)
        {
            try
            {
                if (exercicio == null)
                    return BadRequest();

                var created = await exercicioRepository.AddExercicio(exercicio);

                return CreatedAtAction(nameof(GetExercicio), new { id = created.ExercicioId }, created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        // PUT api/Exercicios/5
        [HttpPut]
        public async Task<ActionResult<Exercicio>> Put(Exercicio exercicio)
        {
            try
            {
                var ToUpdate = await exercicioRepository.GetExercicio(exercicio.ExercicioId);

                if (ToUpdate == null)
                    return NotFound($"Exercicio with Id = {exercicio.ExercicioId} not found");

                return await exercicioRepository.UpdateExercicio(exercicio);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE api/Exercicios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Exercicio>> DeleteExercicio(int id)
        {
            try
            {
                var ToDelete = await exercicioRepository.GetExercicio(id);

                if (ToDelete == null)
                {
                    return NotFound($"Exercicio with Id = {id} not found");
                }
                return await exercicioRepository.DeleteExercicio(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }

        }
    }
}
