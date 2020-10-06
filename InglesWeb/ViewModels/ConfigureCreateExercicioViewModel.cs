using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InglesModels;
using Microsoft.AspNetCore.Http;

namespace InglesWeb.ViewModels
{
    public class ConfigureCreateExercicioViewModel
    {
        

        [Required]
        [Display(Name = "Unidade")]
        public string ExercicioNumber { get; set; }

        [Display(Name = "Texto")]
        public string ExercicioTexto { get; set; }

        [Display(Name = "Imagem")]
        public IFormFile ExercicioImagePath { get; set; }

        public int CapituloId { get; set; }
        public string CapituloNumber { get; set; }

    }
}
