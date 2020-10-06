using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InglesModels;

namespace InglesWeb.ViewModels
{
    public class ConfigureDetailExercicioViewModel
    {
        public Exercicio Exercicio { get; set; }

        public IEnumerable<Questao> Questoes { get; set; }
    }
}
