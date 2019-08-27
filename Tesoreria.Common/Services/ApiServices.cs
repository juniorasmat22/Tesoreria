using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tesoreria.Common.Models;

namespace Tesoreria.Common.Services
{
    public class ApiServices
    {
    // sirve para listar cualquier entidad
        public async Task<Response> GetListAsync<T>(
           string urlBase,
           string controller)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{controller}";
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();//leela como string ->ReadAsStringAsync()

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Mensaje = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Resultado = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Mensaje = ex.Message
                };
            }
        }

    }
}
