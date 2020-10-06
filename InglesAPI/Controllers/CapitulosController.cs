using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InglesAPI.Models;
using InglesModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InglesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapitulosController : ControllerBase
    {
        private readonly ICapituloRepository capituloRepository;

        public CapitulosController(ICapituloRepository capituloRepository)
        {
            this.capituloRepository = capituloRepository;
        }

        // GET: api/Capitulos
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await capituloRepository.GetCapitulos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET api/Capitulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Capitulo>>  Get(int id)
        {
            try
            {
                var result = await capituloRepository.GetCapitulo(id);

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

        // POST api/Capitulos
        [HttpPost]
        public async Task<ActionResult<Capitulo>> Post(Capitulo capitulo)
        {
            try
            {
                if (capitulo == null)
                    return BadRequest();

                var createdCapitulo = await capituloRepository.AddCapitulo(capitulo);

                return CreatedAtAction(nameof(Get),new { id = createdCapitulo.CapituloId }, createdCapitulo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }

        }

        // PUT api/Capitulos/5
        [HttpPut]
        public async Task<ActionResult<Capitulo>> Put(Capitulo capitulo)
        {
            try
            {
                var capituloToUpdate = await capituloRepository.GetCapitulo(capitulo.CapituloId);

                if (capituloToUpdate == null)
                    return NotFound($"Capitulo with Id = {capitulo.CapituloId} not found");

                return await capituloRepository.UpdateCapitulo(capitulo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }


        }

        // DELETE api/Capitulos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Capitulo>> Delete(int id)
        {
            try
            {
                var capituloToDelete = await capituloRepository.GetCapitulo(id);

                if (capituloToDelete == null)
                {
                    return NotFound($"Capitulo with Id = {id} not found");
                }

                return await capituloRepository.DeleteCapitulo(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }

        }
    }
}
