using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InglesModels
{
    public class Capitulo
    {
        public int CapituloId { get; set; }

        [Required]
        public string CapituloNumber { get; set; }

        [Required]
        public string CapituloNome { get; set; }

        public string CapituloTeoria { get; set; }


    }
}
