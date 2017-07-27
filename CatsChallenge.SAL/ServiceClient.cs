using System.Collections.Generic;
using CatsChallenge.Entities;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CatsChallenge.SAL
{
    public class ServiceClient
    {
        /// <summary>
        /// Obtiene la lista de Gatos.
        /// </summary>
        /// <returns>Una lista con las Gatos.</returns>
        public async Task<List<Cat>> GetCatsAsync()
        {
            List<Cat> Cats = null;
            // Dirección base de la Web API
            string URI = "https://ticapacitacion.com/cats";
            // using: liberar recursos
            using (var Client = new HttpClient())
            {
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    // Realizamos una petición GET
                    var Response = await Client.GetAsync(URI);
                    if (Response.StatusCode == HttpStatusCode.OK)
                    {
                        // Si el estatus de la respuesta HTTP fue exitosa, leemos
                        // el valor devuelto.
                        var ResultWebAPI = await Response.Content.ReadAsStringAsync();
                        Cats = JsonConvert.DeserializeObject<List<Cat>>(ResultWebAPI);
                    }
                }
                catch (System.Exception)
                {
                    // Aquí podemos poner el código para manejo de excepciones.
                }
            }
            return Cats;
        }
    }
}