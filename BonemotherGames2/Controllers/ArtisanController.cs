using BonemotherGames2.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArtisanController : ControllerBase
    {
        [HttpGet("{artisanLookupId}")]
        public string Get(int artisanLookupId)
        {
            Artisan artisan = new Artisan();
            artisan = artisan.ConstructArtisan(artisanLookupId);
            var json = JsonConvert.SerializeObject(artisan, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
    }
}