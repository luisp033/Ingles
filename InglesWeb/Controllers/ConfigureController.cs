using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InglesModels;
using InglesWeb.Services;
using InglesWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InglesWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ConfigureController : Controller
    {
        private readonly ICapituloService capituloService;
        private readonly ILogger<ConfigureController> logger;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IExercicioService exercicioService;

        public ConfigureController(ICapituloService capituloService,
                                   ILogger<ConfigureController> logger,
                                   IWebHostEnvironment hostingEnvironment,
                                   IExercicioService exercicioService)
        {
            this.capituloService = capituloService;
            this.hostingEnvironment = hostingEnvironment;
            this.exercicioService = exercicioService;
            this.logger = logger;
        }

        #region Capitulo

        public async Task<IActionResult> Index()
        {
            var model = await capituloService.GetCapitulos();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            ConfigureDetailViewModel model = new ConfigureDetailViewModel();

            int.TryParse(id, out int Id);

            model.Capitulo = await capituloService.GetCapitulo(Id);

            model.Exercicios = await exercicioService.GetExerciciosByCapitulo(Id);

            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConfigureCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                Capitulo newCapitulo = new Capitulo
                {
                    CapituloNome = model.CapituloNome,
                    CapituloNumber = model.CapituloNumber,
                    CapituloTeoria = uniqueFileName
                };
                var created = await capituloService.CreateCapitulo(newCapitulo);

                return RedirectToAction("Detail", new { id = created.CapituloId });
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Capitulo capitulo = await capituloService.GetCapitulo(id);
            ConfigureEditViewModel configureEditViewModel = new ConfigureEditViewModel()
            {
                CapituloId = capitulo.CapituloId,
                CapituloNome = capitulo.CapituloNome,
                CapituloNumber = capitulo.CapituloNumber,
                ExistingPhotoPath = capitulo.CapituloTeoria
            };

            return View(configureEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ConfigureEditViewModel model)
        {

            if (ModelState.IsValid)
            {
                Capitulo capitulo = await capituloService.GetCapitulo(model.CapituloId);

                capitulo.CapituloNome = model.CapituloNome;
                capitulo.CapituloNumber = model.CapituloNumber;

                if (model.CapituloTeoria != null)
                {

                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);

                    }
                    capitulo.CapituloTeoria = ProcessUploadedFile(model);
                }

                await capituloService.UpdateCapitulo(capitulo);

                return RedirectToAction("Index");
            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            int.TryParse(id, out int Id);

            await capituloService.DeleteCapitulo(Id);

            return RedirectToAction("Index");
        }

        #endregion

        #region Exercicio
        [HttpGet]
        public async Task<IActionResult> DetailExercicio(string id)
        {
            ConfigureDetailExercicioViewModel model = new ConfigureDetailExercicioViewModel();
            int.TryParse(id, out int Id);
            model.Exercicio = await exercicioService.GetExercicio(Id);

            //model.Questoes = await questaoService.GetQuestoesByExercicio(Id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateExercicio(string id)
        {
            ConfigureCreateExercicioViewModel model = new ConfigureCreateExercicioViewModel();
            int.TryParse(id, out int Id);
            var Cap = await capituloService.GetCapitulo(Id);
            model.CapituloId = Cap.CapituloId;
            model.CapituloNumber = Cap.CapituloNumber;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercicio(ConfigureCreateExercicioViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                Exercicio newExercicio = new Exercicio
                {
                    CapituloId = model.CapituloId,
                    ExercicioTexto = model.ExercicioTexto,
                    ExercicioNumber = model.ExercicioNumber,
                    ExercicioImagePath = uniqueFileName
                };
                var created = await exercicioService.CreateExercicio(newExercicio);

                return RedirectToAction("DetailExercicio", new { id = created.ExercicioId });
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditExercicio(int id)
        {
            Exercicio exercicio = await exercicioService.GetExercicio(id);

            ConfigureEditExercicioViewModel configureEditExercicioViewModel = new ConfigureEditExercicioViewModel()
            {
                ExercicioId = exercicio.ExercicioId,
                ExercicioTexto = exercicio.ExercicioTexto,
                ExercicioNumber = exercicio.ExercicioNumber,
                ExistingPhotoPath = exercicio.ExercicioImagePath,
                CapituloId = exercicio.Capitulo.CapituloId,
                CapituloNumber = exercicio.Capitulo.CapituloNumber
            };

            return View(configureEditExercicioViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditExercicio(ConfigureEditExercicioViewModel model)
        {

            if (ModelState.IsValid)
            {
                Exercicio exercicio = await exercicioService.GetExercicio(model.ExercicioId);
                exercicio.ExercicioTexto = model.ExercicioTexto;
                exercicio.ExercicioNumber = model.ExercicioNumber;

                if (model.ExercicioImagePath != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    exercicio.ExercicioImagePath = ProcessUploadedFile(model);
                }

                await exercicioService.UpdateExercicio(exercicio);

                return RedirectToAction("DetailExercicio",new { Id = model.ExercicioId});
            }

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteExercicio(string id)
        {
            int.TryParse(id, out int Id);

            await exercicioService.DeleteExercicio(Id);

            return RedirectToAction("Index");
        }

        #endregion

        #region Questao

        //TODO: Falta fazer toda a parte das questões

        #endregion

        private string ProcessUploadedFile(ConfigureCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.CapituloTeoria != null)
            {
                string uplaodsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CapituloTeoria.FileName;
                string filePath = Path.Combine(uplaodsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CapituloTeoria.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        private string ProcessUploadedFile(ConfigureCreateExercicioViewModel model)
        {
            string uniqueFileName = null;
            if (model.ExercicioImagePath != null)
            {
                string uplaodsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ExercicioImagePath.FileName;
                string filePath = Path.Combine(uplaodsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ExercicioImagePath.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

    }

}
