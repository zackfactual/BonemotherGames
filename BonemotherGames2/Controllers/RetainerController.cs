using System.Text.Json;
using BonemotherGames.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BonemotherGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RetainerController : ControllerBase
    {
        [HttpGet("{retainerClassId}")]
        public string Get(int retainerClassId)
        {
            Retainer retainer = new Retainer();
            retainer.RetainerClass = retainer.GetRetainerClass(retainerClassId);
            retainer.ConstructRetainer(retainer);

            return JsonSerializer.Serialize(retainer);
        }
    }
}