using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InglesWeb.ViewModels
{
    public class ConfigureEditViewModel: ConfigureCreateViewModel
    {
        public int CapituloId { get; set; }

        public string ExistingPhotoPath { get; set; }

    }
}
