using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InglesModels
{
    public class Exercicio
    {
        public int ExercicioId { get; set; }

        [Required]
        public string ExercicioNumber { get; set; }

        public string ExercicioTexto { get; set; }

        public string ExercicioImagePath { get; set; }

        [Required]
        public int CapituloId { get; set; }

        public Capitulo Capitulo { get; set; }

    }
}
