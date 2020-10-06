using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InglesModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace InglesWeb.Services
{
    public class CapituloService : ICapituloService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<CapituloService> logger;

        public CapituloService(HttpClient httpClient, ILogger<CapituloService> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public async Task<Capitulo> CreateCapitulo(Capitulo newCapitulo)
        {
            var request = JsonConvert.SerializeObject(newCapitulo);

            HttpContent c = new StringContent(request, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync($"api/Capitulos", c);

            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                logger.LogWarning(resp);
                return JsonConvert.DeserializeObject<Capitulo>(resp);
            }
            else
            {
                return null;
            }
        }

        public async Task DeleteCapitulo(int id)
        {
            await httpClient.DeleteAsync($"api/Capitulos/{ id }");
        }

        public async Task<Capitulo> GetCapitulo(int id)
        {
            try
            {

                HttpResponseMessage response = await httpClient.GetAsync($"api/Capitulos/{ id }");

                if (response.IsSuccessStatusCode)
                {
                    var resp = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Capitulo>(resp);
                }
                else 
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return null;
            }

        }

        public async Task<IEnumerable<Capitulo>> GetCapitulos()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"api/Capitulos");
                if (response.IsSuccessStatusCode)
                {
                    var resp = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Capitulo>>(resp);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Capitulo> UpdateCapitulo(Capitulo updatedCapitulo)
        {
            var request = JsonConvert.SerializeObject(updatedCapitulo);

            HttpContent c = new StringContent(request, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync($"api/Capitulos", c);

            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Capitulo>(resp);
            }
            else
            {
                return null;
            }
        }
    }
}
