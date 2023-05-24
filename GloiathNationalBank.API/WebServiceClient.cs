using GloiathNationalBank.Models;
using Newtonsoft.Json;

namespace GloiathNationalBank.API
{
    public class WebServiceClient
    {
        private readonly HttpClient _httpClient;

        public WebServiceClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<CachedTransaction>> GetNewDataFromWebservice()
        {
            var url = "https://localhost:7216/api/Transaction"; // URL real del webservice

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var newdata = JsonConvert.DeserializeObject<List<CachedTransaction>>(jsonResponse);
                    return newdata;
                }
                else
                {
                    // Puedes lanzar una excepción, retornar una lista vacía o aplicar otra lógica según tus necesidades
                    throw new Exception("Error getting the data from the webservice");
                    return new List<CachedTransaction>();
                }
            }
        }
    }

}

