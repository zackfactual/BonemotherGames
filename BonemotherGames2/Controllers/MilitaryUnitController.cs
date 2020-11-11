using BonemotherGames2.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MilitaryUnitController : ControllerBase
    {
        [HttpGet("{rollableUnitId}")]
        public string Get(int rollableUnitId)
        {
            MilitaryUnit militaryUnit = new MilitaryUnit();
            militaryUnit = militaryUnit.BuildUnit(rollableUnitId);
            var json = JsonConvert.SerializeObject(militaryUnit, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
    }
}