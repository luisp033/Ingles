using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InglesModels;

namespace InglesWeb.ViewModels
{
    public class ConfigureDetailViewModel
    {
        public Capitulo Capitulo { get; set; }

        public IEnumerable<Exercicio> Exercicios { get; set; }

    }
}
