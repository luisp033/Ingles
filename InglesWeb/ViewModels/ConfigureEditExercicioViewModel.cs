using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InglesWeb.ViewModels
{
    public class ConfigureEditExercicioViewModel: ConfigureCreateExercicioViewModel
    {
        public int ExercicioId { get; set; }

        public string ExistingPhotoPath { get; set; }

    }
}
