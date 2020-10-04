using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InglesModels
{
    public class Questao
    {
        public int QuestaoId { get; set; }

        [Required]
        public string QuestaoNumber { get; set; }

        [Required]
        public string QuestaoTexto { get; set; }

        [Required]
        public int ExercicioId { get; set; }

        public Exercicio Exercicio { get; set; }

    }
}
