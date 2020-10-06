using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InglesModels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace InglesWeb.Services
{
    public class ExercicioService : IExercicioService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<ExercicioService> logger;

        public ExercicioService(HttpClient httpClient, ILogger<ExercicioService> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public async Task<Exercicio> CreateExercicio(Exercicio newExercicio)
        {
            var request = JsonConvert.SerializeObject(newExercicio);

            HttpContent c = new StringContent(request, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync($"api/Exercicios", c);

            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                logger.LogWarning(resp);
                return JsonConvert.DeserializeObject<Exercicio>(resp);
            }
            else
            {
                return null;
            }
        }

        public async Task DeleteExercicio(int id)
        {
            await httpClient.DeleteAsync($"api/Exercicios/{ id }");
        }

        public async Task<Exercicio> GetExercicio(int id)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"api/Exercicios/{ id }");

                if (response.IsSuccessStatusCode)
                {
                    var resp = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Exercicio>(resp);
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

        public async Task<IEnumerable<Exercicio>> GetExerciciosByCapitulo(int id)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"api/Exercicios/capitulo/{ id }");

                if (response.IsSuccessStatusCode)
                {
                    var resp = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Exercicio>>(resp);
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

        public async Task<Exercicio> UpdateExercicio(Exercicio updatedExercicio)
        {
            var request = JsonConvert.SerializeObject(updatedExercicio);

            HttpContent c = new StringContent(request, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync($"api/Exercicios", c);

            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Exercicio>(resp);
            }
            else
            {
                return null;
            }
        }
    }
}
