using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace InglesWeb.ViewModels
{
    public class ConfigureCreateViewModel
    {

        [Required]
        [Display(Name = "Unidade")]
        public string CapituloNumber { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string CapituloNome { get; set; }

        [Display(Name = "Teoria")]
        public IFormFile CapituloTeoria { get; set; }

    }
}
