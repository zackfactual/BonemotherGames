using System.Text.Json;
using BonemotherGames2.Services;
using Microsoft.AspNetCore.Mvc;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArtisanController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            Artisan artisan = new Artisan();
            artisan.ConstructRandomArtisan(artisan);
            return JsonSerializer.Serialize(artisan);
        }  
    }
}