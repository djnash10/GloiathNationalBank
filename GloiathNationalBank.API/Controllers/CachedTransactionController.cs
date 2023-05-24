using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GloiathNationalBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CachedTransactionController : ControllerBase
    {
        private readonly WebServiceClient _webServiceClient;

        public CachedTransactionController()
        {
            _webServiceClient = new WebServiceClient();
        }

        [HttpGet("Get-new-data")]
        public async Task<IActionResult> GetNewDataFromWebService()
        {
            try
            {
                var nuevosDatos = await _webServiceClient.ObtenerNuevosDatosDelWebservice();
                // Realizar acciones adicionales con los nuevos datos obtenidos
                return Ok(nuevosDatos);
            }
            catch (Exception ex)
            {
                // Manejo del error en caso de excepción
                return StatusCode(500, $"Error al obtener los datos del webservice: {ex.Message}");
            }
        }
    }
}
    

